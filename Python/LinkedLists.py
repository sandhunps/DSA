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


def main():
    head = takeInput()

    while head != None:
        print(head.data , head , head.next , sep=", ")
        head = head.next
      
        
    
if __name__ == "__main__":
     main()
    
    