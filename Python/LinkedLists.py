class Node:
    def __init__(self, data):
        self.data = data
        self.next = None


#Creating Node
node1 = Node(1)
node2 = Node(2)
node3 = Node(3)

#Creating Liked List
node1.next = node2
node2.next = node3

# printing
print(node1.data)
print(node2.data)
print(node1.next.data)
print(node1)
print(node1.next)
print(node2)

def takeInput():
    # The input will be a space separeted value 
    #  eg 1 2 3 4 5 -1
    # -1 indicating end of input
    # we will create list of int from this input using list comprehension
    # new_list = [expression for item in iterable if condition]


    inputList = [int(ele) for ele in input().split()]
    head = None
    currNode = None
    for ele in inputList:

        if ele == -1:
            break

        newNode = Node(ele)

        if currNode != None:
            currNode.next = newNode
        
        currNode = newNode

        if head is None:
            head = newNode

    return head

head = takeInput()

while head != None:
    print(head.data , head , head.next , sep=", ")
    head = head.next
    