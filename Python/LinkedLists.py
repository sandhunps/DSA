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
    node_pointer = 0
    curr = head


    while curr != None:
        if i == node_pointer-1:
            newNode.next = curr.next
            curr.next = newNode
            return head
        node_pointer += 1
        curr = curr.next
    

        




def main():
    head = takeInput()

    Print_ith_node(head, 3)

    head = Insert_ith_node(head , 3 , 4)


    while head != None:
        print(head.data , head , head.next , sep=", ")
        head = head.next
      
        
    
if __name__ == "__main__":
     main()
    
    