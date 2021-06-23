using System;
using static System.Console;

class Tree {
    public static void commandHelp() {
        WriteLine("\nEnter one of the following commands below: \n");
        WriteLine("insert {val} - Insert value to the Red Black Tree");
        WriteLine("delete {val} - Delete value from Red Black Tree");
        WriteLine("search {val} - Search value in the Red Black Tree");
        WriteLine("random {val} - Build a Red Black Tree with specified number of random values");
        WriteLine("compare {val} random - Compare performance of Binary Search and Red Black Trees with specified number of random values");
        WriteLine("compare {val} sequence - Compare performance of Binary Search and Red Black Trees with increasing sequence of values");
        WriteLine("print - Print current tree structure");
        WriteLine("clean - Clean the tree");
        WriteLine("usage - Print usage of commands");
        WriteLine("quit - Exit the program\n");
    }

    public static void printTree(RBT<int> rbt) {
        WriteLine("\nTree Structure:\n");
        rbt.printFormattedTree();
        WriteLine();
    }

    public static void comparePerformance(double rbt, double bst) {
        if (bst > rbt) 
            WriteLine($"\nRBT was {(bst / rbt):f2} times faster than BST\n");
        else if (rbt > bst)
            WriteLine($"\nBST was {(bst / rbt):f2} times faster than RBT\n");
        else 
            WriteLine("Performance of both trees was the same");
    }

    public static int handleUserInputError(string[] line, ref int val) {
        if (line[0] == "") {
            WriteLine("\nInvalid command structure. Enter usage to see details ...\n");
            return 1;
        }

        if (line[0] != "quit" && line[0] != "usage" && line[0] != "print" && line[0] != "clean") {
            if (line.Length == 1 ) {
                WriteLine("\nInvalid command structure. Enter usage to see details ...\n");
                return 1;
            }

            try {
                val = Int32.Parse(line[1]);
            } catch (System.FormatException) {
                WriteLine("\nEnter Valid Value ...\n");
                return 1;
            }
        }

        return 0;
    }    
    
    public static void handleRandomValues(int val, ref RBT<int> rbt) {
        Random r = new Random();
        int[] nums = new int[val];
        for (int i = 0; i < val; i++) 
            nums[i] = r.Next(val + 1);
        
        foreach (int i in nums) {
            rbt.add(i);
            printTree(rbt);
        }

        WriteLine("List of generated random numbers above: ");

        foreach(int i in nums) {
            if (i != nums[nums.Length - 1]) 
                Write(i.ToString() + ", ");
            else
                Write(i.ToString() + " ");
        }

        WriteLine('\n');
    }

    public static int performanceValidityCheck(int val, string[] line) {
        if (line.Length != 3) {
            WriteLine("\nInvalid command structure. Enter usage to see details ...\n");
            return 1;
        }

        try {
            val = Int32.Parse(line[1]);
        } catch (System.FormatException) {
            return 1;
        }

        return 0;
    }

    public static (double, double, double, double, double, double) handleComparisonTime(int[] values, 
        ref RBT<int> rbt, ref BST<int> bst) {

        DateTime startBstInsert = DateTime.Now;
        foreach(int i in values) 
            bst.add(i);
        DateTime endBstInsert = DateTime.Now;

        DateTime startRbtInsert = DateTime.Now;
        foreach(int i in values)
            rbt.add(i);
        DateTime endRbtInsert = DateTime.Now;

        double rbtInsert = (endRbtInsert - startRbtInsert).TotalMilliseconds;
        double bstInsert = (endBstInsert - startBstInsert).TotalMilliseconds;

        DateTime startRbtContain = DateTime.Now;
        foreach(int i in values)
            rbt.contains(i);
        DateTime endRbtContain = DateTime.Now;

        DateTime startBstContain = DateTime.Now;

        foreach(int i in values)
            bst.contains(i);

        DateTime endBstContain = DateTime.Now;

        double rbtContain = (endRbtContain - startRbtContain).TotalMilliseconds;;
        double bstContain = (endBstContain - startBstContain).TotalMilliseconds;;

        DateTime startBstRemove = DateTime.Now;
        foreach(int i in values)
            bst.remove(i);
        DateTime endBstRemove = DateTime.Now;
        
        DateTime startRbtRemove = DateTime.Now;
        foreach(int i in values) 
            rbt.remove(i);
        DateTime endRbtRemove = DateTime.Now;

        double rbtRemove = (endRbtRemove - startRbtRemove).TotalMilliseconds;
        double bstRemove = (endBstRemove - startBstRemove).TotalMilliseconds;

        return (rbtInsert, bstInsert, rbtContain, bstContain, rbtRemove, bstRemove);
    }

    public static void handleCompareRandom(int val, ref BST<int> bst, ref RBT<int> rbt) {
        string type = "random";
        Random randNums = new Random();
        int[] values  = new int[val];
        for (int i = 0; i < val; i++)
            values[i] = randNums.Next(val + 1);

        (double rbtInsert, double bstInsert, double rbtContain, double bstContain, double rbtRemove, double bstRemove)
        = handleComparisonTime(values, ref rbt, ref bst);

        printPerformanceRandom(val, rbtInsert, bstInsert, rbtContain, bstContain, rbtRemove, bstRemove, type);
    }

    public static void printPerformanceRandom(int val, double rbtInsert, double bstInsert, 
                double rbtContain, double bstContain, double rbtRemove, double bstRemove, string type) {

        WriteLine("\nPERFORMANCE RESULTS: \n");

        WriteLine("\n1.INSERT FUNCTION \n");
        WriteLine($"\nInsert function in BST with {val} number of {type} values took {bstInsert} milliseconds");
        WriteLine($"\nInsert function in RBT with {val} number of {type} values took {rbtInsert} milliseconds");
        
        comparePerformance(rbtInsert, bstInsert);

        WriteLine("\n2.CONTAIN FUNCTION \n");
        WriteLine($"\nContain function in BST with {val} number of {type} values took {bstContain} milliseconds");
        WriteLine($"\nContain function in RBT with {val} number of {type} values took {rbtContain} milliseconds");
        
        comparePerformance(rbtContain, bstContain);

        WriteLine("\n3.REMOVE FUNCTION \n");
        WriteLine($"\nRemove function in BST with {val} number of {type} values took {bstRemove} milliseconds");
        WriteLine($"\nRemove function in RBT with {val} number of {type} values took {rbtRemove} milliseconds");
        
        comparePerformance(rbtRemove, bstRemove);
    }

    public static void handleCompareSequence(int val, ref BST<int> bst, ref RBT<int> rbt) {
        string type = "increasing sequence";
        int[] values = new int[val];
        for(int i = 0; i < val; i++)
            values[i] = i;

        (double rbtInsert, double bstInsert, double rbtContain, double bstContain, double rbtRemove, double bstRemove)
        = handleComparisonTime(values, ref rbt, ref bst);

        printPerformanceRandom(val, rbtInsert, bstInsert, rbtContain, bstContain, rbtRemove, bstRemove, type);
    }

    public static int handleUserCommands(string[] line, ref RBT<int> rbt, ref BST<int> bst, int val) {
        switch(line[0]) {
            case "insert":
                rbt.add(val);
                printTree(rbt);
                return 0;
            case "delete":
                rbt.remove(val);
                printTree(rbt);
                return 0;
            case "search":
                rbt.contains(val);
                WriteLine();
                return 0;
            case "random":
                handleRandomValues(val, ref rbt);
                return 0;
            case "compare":
                rbt = new RBT<int>();
                bst = new BST<int>();
                int exit_code = performanceValidityCheck(val, line);

                if (exit_code == 1) 
                    return 0;
                if (line[2] == "random") 
                    handleCompareRandom(val, ref bst, ref rbt);
                else if (line[2] == "sequence")
                    handleCompareSequence(val, ref bst, ref rbt);
                else {
                    WriteLine("\nInvalid command structure. Enter usage to see details ...\n");
                    return 0;
                } return 0;
            case "clean":
                rbt = new RBT<int>();
                WriteLine("\nCleaned the tree ...\n");
                printTree(rbt);
                return 0;
            case "usage":
                commandHelp();
                return 0;
            case "print":
                printTree(rbt);
                return 0;
            case "quit":
                WriteLine("\nExiting the program ...\n");
                return 1;
            default:
                WriteLine("\nInvalid command. Choose one of the commands above\n");
                return 0;
        }
    }

    public static void Main() {
        RBT<int> rbt = new RBT<int>();
        BST<int> bst = new BST<int>();

        commandHelp();

        while (true) {
            Write("\nEnter command: ");

            string commands = ReadLine();
            string[] line = commands.Split();

            int val = 0;

            int exit_val = handleUserInputError(line, ref val);
            if (exit_val == 1)
                continue;
            
            int command_exit_val = handleUserCommands(line, ref rbt, ref bst, val);
            if (command_exit_val == 0)
                continue;
            else if (command_exit_val == 1)
                return;
        }
    }
}