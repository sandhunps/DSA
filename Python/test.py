
# Definition for singly-linked list node
class Node:
    def __init__(self, data):
        self.data = data
        self.next = None

# Function to find the length of a singly linked list
def find_length(head):
    length = 0
    current = head
    
    while current is not None:
        length += 1
        current = current.next
    
    return length

# Function to take input and call find_length function
def main():
    t = int(input())
    
    for _ in range(t):
        elements = list(map(int, input().split()))
        head = None
        tail = None

        # Creating the linked list
        for data in elements:
            if data == -1:
                break
            new_node = Node(data)
            if head is None:
                head = new_node
                tail = new_node
            else:
                tail.next = new_node
                tail = new_node

        # Finding and printing the length of the linked list
        print(find_length(head))

if __name__ == "__main__":
    main()
