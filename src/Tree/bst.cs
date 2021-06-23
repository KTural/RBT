using System;
using static System.Console;

class Node<T> {
    public Node<T> left;
    public T val;
    public Node<T> right;
    public Node(T val) {
        this.val = val;
    }
}
class BST<T> where T : IComparable<T> {
    public Node<T> root;

    public bool contains(T val) {
        Node<T> n = root;

        while (n != null) {
            if (n.val.CompareTo(val) < 0) {
                n = n.left;
            } else if (n.val.CompareTo(val) > 0) {
                n = n.right;
            } else {
                if (n.val.CompareTo(val) == 0) {
                    WriteLine($"BST CONTAINS \"{val}\"");
                    return true;
                }
            }
        }
        WriteLine($"BST DOESN'T CONTAIN \"{val}\"");
        return false;
    }

    public bool add(T val) {
        Node<T> n = root;
        string added_val = $"ADDED \"{val}\" TO BST";
        string existing_val = $"\"{val}\" CAN'T BE ADDED. BST ALREADY CONTAINS \"{val}\"";

        if (root == null) {
            root = new Node<T>(val);
            WriteLine(added_val);
            return true;
        }

        while (n.val.CompareTo(val) != 0) {
            if (n.val.CompareTo(val) < 0) {
                if (n.left == null) {
                    n.left = new Node<T>(val);
                    WriteLine(added_val);
                    return true;
                } else {
                    n = n.left;
                }
            } else {
                if (n.val.CompareTo(val) > 0) {
                    if (n.right == null) {
                        n.right = new Node<T>(val);
                        WriteLine(added_val);
                        return true;
                    } else {
                        n = n.right;
                    }
                }
            }
        }
        WriteLine(existing_val);
        return false;
    }

    public bool remove(T val) {
        int left_subtree = 0;
        string no_val = $"CAN'T REMOVE \"{val}\". \"{val}\" IS NOT IN BST";
        string existing_val = $"REMOVED \"{val}\"";

        Node<T> n = root;
        Node<T> parent = null;

        while (n != null) {
            if (n.val.CompareTo(val) < 0) {
                parent = n;
                n = n.left;
                left_subtree = 1;
            } else if (n.val.CompareTo(val) > 0) {
                parent = n;
                n = n.right;
                left_subtree = 0;
            } else {
                if (n.left == null) {
                    modifyTree(parent, left_subtree, n.right);
                } else if (n.right == null) {
                    modifyTree(parent, left_subtree, n.left);
                } else {
                    n.right = extractMin(n.right, out n.val);
                }
                WriteLine(existing_val);
                return true;
            }
        }
        WriteLine(no_val);
        return false;
    }

    public static Node<T> extractMin(Node<T> cur_tree, out T min_val) {
        Node<T> n = cur_tree;

        if (cur_tree.left == null) {
            min_val = cur_tree.val;
            return cur_tree.right;
        }

        while (n.left.left != null) {
            n = n.left;
        }

        min_val = n.left.val;
        n.left = n.left.right;
        return cur_tree;
    }

    public void modifyTree(Node<T> parent, int left_subtree, Node<T> modified_tree) {
        if (parent == null) {
            root = modified_tree;
        } else if (left_subtree == 1) {
            parent.left = modified_tree;
        } else {
            parent.right = modified_tree;
        }
    }
}