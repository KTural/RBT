using System;
using static System.Console;

enum Color {
    RED, BLACK
}
class RBNode<T> {
    public RBNode<T> left;
    public RBNode<T> right;
    public RBNode<T> parent;
    public T val;
    public Color  color;

    public RBNode() {}

    public RBNode(T val) {
        this.val = val;
    }
    public RBNode(Color  color) {
        this.color = color;
    }
    public RBNode(T val, Color  color) {
        this.val = val;
        this.color = color;
    }
}

class RBT<T> where T : IComparable<T> {
    public RBNode<T> root;
    public static RBNode<T> leaf;
    public RBT() {
        root = new RBNode<T>();
        leaf = new RBNode<T>();
        leaf.color = Color.BLACK;
        leaf.left = null;
        leaf.right = null;
        leaf.parent = null;
        root = leaf;
    }

    public bool contains(T key) {
        return contains(key, root);
    }

    public static bool contains(T key, RBNode<T> n) {
        if (n == leaf) {
            WriteLine($"\nRBT DOESN'T CONTAIN \"{key}\"");
            return false;
        }

        if (key.CompareTo(n.val) == 0) {
            WriteLine($"\nRBT CONTAINS \"{key}\"");
            return true;
        }

        if (key.CompareTo(n.val) < 0) {
            return contains(key, n.left);
        } else {
            return contains(key, n.right);
        }
    }

    public RBNode<T> findKey(T key) {
        RBNode<T> cur_node = root;

        if (cur_node == leaf) {
            return null;
        }
        
        while(cur_node.val.CompareTo(key) != 0) {
            if (cur_node == leaf) {
                return null;
            }
            if (key.CompareTo(cur_node.val) < 0) {
                cur_node = cur_node.left;
            } else if (key.CompareTo(cur_node.val) > 0) {
                cur_node = cur_node.right;
            }
        }

        return cur_node;
    }

    public RBNode<T> findMaxNode(RBNode<T> cur_node) {
        RBNode<T> cur = cur_node;

        while (cur.right != leaf) {
            cur = cur.right;
        }

        return cur;
    }

    public RBNode<T> findMinNode(RBNode<T> cur_node) {
        RBNode<T> cur = cur_node;

        while (cur.left != leaf) {
            cur = cur.left;
        }

        return cur;
    }   

    public void leftRotate(RBNode<T> cur_node) {
        RBNode<T> n = cur_node.right;
        cur_node.right = n.left;

        if (n.left != leaf) {
            n.left.parent = cur_node;
        }

        n.parent = cur_node.parent;

        if (cur_node.parent == leaf) {
            root = n;
        } else if (cur_node.parent.left == cur_node) {
            cur_node.parent.left = n;
        } else {
            cur_node.parent.right = n;
        }

        n.left = cur_node;
        cur_node.parent = n;
    }

    public void rightRotate(RBNode<T> cur_node) {
        RBNode<T> n = cur_node.left;
        cur_node.left = n.right;

        if (n.right != leaf) {
            n.right.parent = cur_node;
        }

        n.parent = cur_node.parent;

        if (cur_node.parent == leaf) {
            root = n;
        } else if (cur_node.parent.right == cur_node) {
            cur_node.parent.right = n;
        } else {
            cur_node.parent.left = n;
        }

        n.right = cur_node;
        cur_node.parent = n;
    }

    public RBNode<T> findSuccessor(RBNode<T> cur_node) {
        if (cur_node.right != leaf) {
            return findMinNode(cur_node.right);
        }

        RBNode<T> n = cur_node.parent;
        
        while (n != leaf && cur_node == n.right) {
            cur_node = n;
            n = n.parent;
        }

        return n;
    }

    public RBNode<T> findPredecessor(RBNode<T> cur_node) {
        if (cur_node.left != leaf) {
            return findMaxNode(cur_node.left);
        }

        RBNode<T> n = cur_node.parent;

        while (n != leaf && cur_node == n.left) {
            cur_node = n;
            n = n.parent;
        }

        return n;
    }

    public void add(T val) {
        RBNode<T> n = new RBNode<T>();
        n.parent = null;
        n.val = val;
        n.left = leaf;
        n.right = leaf;
        n.color = Color.RED;
        RBNode<T> y = leaf;
        RBNode<T> r = root;

        while (r != leaf) {
            y = r;
            if (n.val.CompareTo(r.val) < 0) {
                r = r.left;
            } else if (n.val.CompareTo(r.val) > 0) {
                r = r.right;
            } else if (n.val.CompareTo(r.val) == 0) {
                WriteLine($"\n\"{val}\" is already in RBT");
                return;
            }
        }

        n.parent = y;
        
        if (y == leaf) {
            root = n;
        } else if (n.val.CompareTo(y.val) < 0) {
            y.left = n;
        } else if (n.val.CompareTo(y.val) > 0) {
            y.right = n;
        } else if (n.val.CompareTo(y.val) == 0) {
            WriteLine($"\n\"{val}\" is already in RBT");
            return;
        }

        if (n.parent == leaf) {
            WriteLine($"\nADDED \"{val}\" TO THE RBT");
            n.color = Color.BLACK;
            return;
        }

        if (n.parent.parent == leaf) {
            WriteLine($"\nADDED \"{val}\" TO THE RBT");
            return;
        }

        addFix(n);

        WriteLine($"\nADDED \"{val}\" TO THE RBT");
    }

    public void addFix(RBNode<T> n) {
        RBNode<T> y;

        while (n.parent.color == Color.RED) {
            if (n.parent == n.parent.parent.left) {
                y = n.parent.parent.right;
                if (y.color == Color.RED) {
                    n.parent.color = Color.BLACK;
                    y.color = Color.BLACK;
                    n.parent.parent.color = Color.RED;
                    n = n.parent.parent;
                } else {
                    if (n == n.parent.right) {
                        n = n.parent;
                        leftRotate(n);
                    }
                    n.parent.color = Color.BLACK;
                    n.parent.parent.color = Color.RED;
                    rightRotate(n.parent.parent);
                }
            } else {
                y = n.parent.parent.left;
                if (y.color == Color.RED) {
                    n.parent.color = Color.BLACK;
                    y.color = Color.BLACK;
                    n.parent.parent.color = Color.RED;
                    n = n.parent.parent;
                } else {
                    if (n == n.parent.left) {
                        n = n.parent;
                        rightRotate(n);
                    }
                    n.parent.color = Color.BLACK;
                    n.parent.parent.color = Color.RED;
                    leftRotate(n.parent.parent);
                }
            }

            if (n == root)
                break;

        }

        root.color = Color.BLACK;
    }

    public void remove(T val) {
        RBNode<T> x; RBNode<T> y;
        RBNode<T> n = findKey(val);

        if (n == null) {
            WriteLine($"\n\"{val}\" is not in RBT");
            return;
        }

        if (n.left == leaf || n.right == leaf) {
            y = n;
        } else {
            y = findMinNode(n.right);
        }

        if (y.left != leaf) {
            x = y.left;
        } else {
            x = y.right;
        }

        x.parent = y.parent;

        if (y.parent == leaf) {
            root = x;
        } else {
            if (y.parent.left == y) {
                y.parent.left = x;
            } else {
                y.parent.right = x;
            }
        }

        if (y != n) {
            n.val = y.val;
        }

        if (y.color == Color.BLACK) {
            removeFix(x);
        }

        WriteLine($"\nREMOVED \"{val}\" FROM RBT");
    }

    public void removeFix(RBNode<T> n) {
        RBNode<T> r;
        while (n != root && n.color == Color.BLACK) {
            if (n == n.parent.left) {
                r = n.parent.right;
                if (r.color == Color.RED) {
                    r.color = Color.BLACK;
                    n.parent.color = Color.RED;
                    leftRotate(n.parent);
                    r = n.parent.right;
                } if (r.left.color == Color.BLACK && r.right.color == Color.BLACK) {
                    r.color = Color.RED;
                    n = n.parent;
                } else {
                    if (r.right.color == Color.BLACK) {
                        r.left.color = Color.BLACK;
                        r.color = Color.RED;
                        rightRotate(r);
                        r = n.parent.right;
                    }
                    r.color = n.parent.color;
                    n.parent.color = Color.BLACK;
                    r.right.color = Color.BLACK;
                    leftRotate(n.parent);
                    n = root;
                }
            } else {
                r = n.parent.left;
                if (r.color == Color.RED) {
                    r.color = Color.BLACK;
                    n.parent.color = Color.RED;
                    rightRotate(n.parent);
                    r = n.parent.left;
                } if (r.left.color == Color.BLACK && r.right.color == Color.BLACK) {
                    r.color = Color.RED;
                    n = n.parent;
                } else {
                    if (r.left.color == Color.BLACK) {
                        r.right.color = Color.BLACK;
                        r.color = Color.RED;
                        leftRotate(r);
                        r = n.parent.left;
                    }
                    r.color = n.parent.color;
                    n.parent.color = Color.BLACK;
                    r.left.color = Color.BLACK;
                    rightRotate(n.parent);
                    n = root;
                }
            }
        }

        n.color = Color.BLACK;
    }

    public void printSimpleTree() {
        printSimpleTree(root, 0);
    }

    public static void printSimpleTree(RBNode<T> node, int depth) {
        if (node == null) {
            return;
        }

        printSimpleTree(node.right, depth + 1);
        WriteLine(new string(' ', depth * 4) + node.val);
        printSimpleTree(node.left, depth + 1);
    }

    public void printFormattedTree() {
        printFormattedTree(root, 4);
    }

    public void printFormattedTree(RBNode<T> n, int pad) {
        if (n != null) {
            if (n.right != null) {
                printFormattedTree(n.right, pad + 4);
            } if (pad > 0) {
                Write(" ".PadLeft(pad));
            } if (n.right != null) {
                Write("/\n");
                Write(" ".PadLeft(pad));
            }

            Write(n.val.ToString() + "\n ");

            if (n.left != null) {
                Write(" ".PadLeft(pad) + "\\\n");
                printFormattedTree(n.left, pad + 4);
            }
        }
    }
}