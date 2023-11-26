class Node:
    def __init__(self, data):
        self.data = data
        self.next = None


def takeInput():
    inputList = [int(ele) for ele in input().split()]
    head = None
    tail = None
    for ele in inputList:

        if ele == -1:
            break

        newNode = Node(ele)

        # For first element set head and tail 
        # For rest , keep head the same. 
        if head == None:
            head = newNode
            tail = newNode
        else:
            tail.next = newNode
            tail = newNode
        

    return head


def Print_ith_node(head, i):
    node_pointer = 0
    
    while head != None:
        if i == node_pointer:
            print(f"The value of the {i}th node is: {head.data}")
            return
        node_pointer += 1
        head = head.next
    print(f"Error: The index {i} was not found")


def Insert_ith_node(head, i , data):
    newNode = Node(data)
    index = 0
    # keep track of the current node and previous node 
    currNode = head
    prevNode = None

    # Boundary condition : If we need to insert node at the begining,
    # Make the new node the head  
    if(i == 0):
        newNode.next = head
        head = newNode
        return head


    while currNode != None:
        if i == index:
            prevNode.next = newNode
            newNode.next = currNode
            return head
        index += 1
        prevNode = currNode
        currNode = currNode.next

    print(F"No Node found at {i}th Position")
    return head

def delete_ith_Node(head, i):
    if (i == 0):
        new_head = head.next
        head.next = None # Dissconnet the node
        return new_head
    
    currNode = head
    prevNode = None
    index = 0

    while currNode != None:
        if i == index:
            prevNode.next = currNode.next
            currNode.next = None #Disconnect the node
            return head
        prevNode = currNode
        currNode = currNode.next
        index += 1

    print(F"No such node {i}th position")
    return head
    

    



def main():
    head = takeInput()

    Print_ith_node(head, 3)

    head = Insert_ith_node(head , 7 , 6)

    head = delete_ith_Node(head, 6)


    while head != None:
        print(head.data , head , head.next , sep=", ")
        head = head.next
      
        
    
if __name__ == "__main__":
     main()
    
    