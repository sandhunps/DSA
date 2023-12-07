import LinkedLists2 as LL2

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

def Insert_ith_node_Recursively(head, i, data):
    newNode = Node(data)
    
    if i == 0 and head is not None:
        newNode.next = head
        head = newNode
        return newNode
        

    head.next = Insert_ith_node_Recursively(head.next,i-1,data)
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
    

def delete_ith_Node_Recursively(head , i):
    
    if head is None:
        return None

    if i == 0:
        newhead = head.next
        head.next = None
        return newhead
    
    
    head.next = delete_ith_Node_Recursively(head.next, i-1)
    return head

def removeNthFromEnd(head:Node, n: int):
        len = 0
        node = head
        while node:
            node = node.next
            len += 1
        
        delNode = (len-n)+1

        dummy = Node(-1)
        dummy.next = head
        prev = dummy
        curr = head
        k = 1

        while curr:
            if(k == delNode):
                prev.next = curr.next
                return dummy.next
            else:
                prev = curr
                curr = curr.next
                k += 1
        return dummy.next


def swapPairs(head: Node):
        dummy = Node(-1)
        dummy.next = head
        prev = dummy
        curr = head

        while(curr and curr.next):
            prev.next.next = curr.next

            prev = curr
            curr = curr.next
        return dummy.next


def main():
    head = takeInput()
    #head =  removeNthFromEnd(head=head, n=2)
    head  = swapPairs(head)
    # Print_ith_node(head, 3)

    # head = Insert_ith_node_Recursively(head , 2 , 6)

    # head = delete_ith_Node_Recursively(head, 2)
     
    # head = LL2.reverseLL(head)
    

    while head != None:
        print(head.data , head , head.next , sep=", ")
        head = head.next
      
        
    
if __name__ == "__main__":
     main()
    
    