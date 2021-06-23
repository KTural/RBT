# RBT

### Content

Red-Black Tree implementation, performance, and runtime difference of operations between Binary Search Tree

### Sample Usage

```sh
$ dotnet run

Enter one of the following commands below: 

insert {val} - Insert value to the Red Black Tree
delete {val} - Delete value from Red Black Tree
search {val} - Search value in the Red Black Tree
random {val} - Build a Red Black Tree with specified number of random values
compare {val} random - Compare performance of Binary Search and Red Black Trees with specified number of random values
compare {val} sequence - Compare performance of Binary Search and Red Black Trees with increasing sequence of values
print - Print current tree structure
clean - Clean the tree
usage - Print usage of commands
quit - Exit the program


Enter command: insert 10

ADDED "10" TO THE RBT

Tree Structure:

        0
     /
    10
     \
        0
 

Enter command: insert 15

ADDED "15" TO THE RBT

Tree Structure:

            0
         /
        15
         \
            0
     /
    10
     \
        0
 

Enter command: insert 2

ADDED "2" TO THE RBT

Tree Structure:

            0
         /
        15
         \
            0
     /
    10
     \
            0
         /
        2
         \
            0
 

Enter command: delete 2

REMOVED "2" FROM RBT

Tree Structure:

            0
         /
        15
         \
            0
     /
    10
     \
        0
 

Enter command: delete 10

REMOVED "10" FROM RBT

Tree Structure:

        0
     /
    15
     \
        0
 

Enter command: search 15

RBT CONTAINS "15"


Enter command: usage

Enter one of the following commands below: 

insert {val} - Insert value to the Red Black Tree
delete {val} - Delete value from Red Black Tree
search {val} - Search value in the Red Black Tree
random {val} - Build a Red Black Tree with specified number of random values
compare {val} random - Compare performance of Binary Search and Red Black Trees with specified number of random values
compare {val} sequence - Compare performance of Binary Search and Red Black Trees with increasing sequence of values
print - Print current tree structure
clean - Clean the tree
usage - Print usage of commands
quit - Exit the program


Enter command: random 5

ADDED "1" TO THE RBT

Tree Structure:

        0
     /
    15
     \
            0
         /
        1
         \
            0
 

ADDED "4" TO THE RBT

Tree Structure:

            0
         /
        15
         \
            0
     /
    4
     \
            0
         /
        1
         \
            0
 

ADDED "3" TO THE RBT

Tree Structure:

            0
         /
        15
         \
            0
     /
    4
     \
                0
             /
            3
             \
                0
         /
        1
         \
            0
 

ADDED "2" TO THE RBT

Tree Structure:

            0
         /
        15
         \
            0
     /
    4
     \
                0
             /
            3
             \
                0
         /
        2
         \
                0
             /
            1
             \
                0
 

"2" is already in RBT

Tree Structure:

            0
         /
        15
         \
            0
     /
    4
     \
                0
             /
            3
             \
                0
         /
        2
         \
                0
             /
            1
             \
                0
 
List of generated random numbers above: 
1, 4, 3, 2 2 


Enter command: print

Tree Structure:

            0
         /
        15
         \
            0
     /
    4
     \
                0
             /
            3
             \
                0
         /
        2
         \
                0
             /
            1
             \
                0
 

Enter command: compare 100 sequence
ADDED "0" TO BST
...
ADDED "99" TO BST

ADDED "0" TO THE RBT

...

ADDED "99" TO THE RBT

RBT CONTAINS "0"

RBT CONTAINS "1"

...

RBT CONTAINS "99"
BST CONTAINS "0"
...
BST CONTAINS "98"
BST CONTAINS "99"
REMOVED "0"
...
REMOVED "98"
REMOVED "99"

REMOVED "0" FROM RBT

REMOVED "1" FROM RBT

...

REMOVED "99" FROM RBT

PERFORMANCE RESULTS: 


1.INSERT FUNCTION 


Insert function in BST with 100 number of increasing sequence values took 24.404 milliseconds

Insert function in RBT with 100 number of increasing sequence values took 0.9173 milliseconds

RBT was 26.60 times faster than BST


2.CONTAIN FUNCTION 


Contain function in BST with 100 number of increasing sequence values took 1.2355 milliseconds

Contain function in RBT with 100 number of increasing sequence values took 0.742 milliseconds

RBT was 1.67 times faster than BST


3.REMOVE FUNCTION 


Remove function in BST with 100 number of increasing sequence values took 1.4739 milliseconds

Remove function in RBT with 100 number of increasing sequence values took 0.9715 milliseconds

RBT was 1.52 times faster than BST


Enter command: compare 100 random
ADDED "59" TO BST
ADDED "35" TO BST
ADDED "18" TO BST
ADDED "96" TO BST
"2" CAN'T BE ADDED. BST ALREADY CONTAINS "2"
...
"79" CAN'T BE ADDED. BST ALREADY CONTAINS "79"
"96" CAN'T BE ADDED. BST ALREADY CONTAINS "96"
ADDED "55" TO BST

ADDED "4" TO THE RBT
...

"96" is already in RBT

ADDED "55" TO THE RBT

RBT CONTAINS "59"

RBT CONTAINS "82"

RBT CONTAINS "79"
...
RBT CONTAINS "96"

BST CONTAINS "59"
BST CONTAINS "1"
...
BST CONTAINS "94"
REMOVED "59"
REMOVED "35"
REMOVED "96"
CAN'T REMOVE "2". "2" IS NOT IN BST
...
REMOVED "55"

REMOVED "59" FROM RBT

...

"96" is not in RBT

REMOVED "55" FROM RBT

PERFORMANCE RESULTS: 


1.INSERT FUNCTION 


Insert function in BST with 100 number of random values took 1.6476 milliseconds

Insert function in RBT with 100 number of random values took 1.2078 milliseconds

RBT was 1.36 times faster than BST


2.CONTAIN FUNCTION 


Contain function in BST with 100 number of random values took 0.9862 milliseconds

Contain function in RBT with 100 number of random values took 1.0787 milliseconds

BST was 0.91 times faster than RBT


3.REMOVE FUNCTION 


Remove function in BST with 100 number of random values took 1.9078 milliseconds

Remove function in RBT with 100 number of random values took 1.3932 milliseconds

RBT was 1.37 times faster than BST


Enter command: clean

Cleaned the tree ...


Tree Structure:

    0
 

Enter command: quit

Exiting the program ...

```
