import LinkedLists1 as LL1

def reverseLL(head):
    curr = head
    prev = None

    while curr is not None:
        tempnode = curr.next
        curr.next = prev

        prev = curr
        curr = tempnode
    return prev


# 1 --> 2 --> 3 -->none
# At node 3:
#    node.next == none
#    head = node.data
#    return head
# At node 2:
#    node.next is node 3
#    node.next.next
#    node.next = null
def reverse_list_recursive(current):
        # Base case: If the current node is None or the last node in the list
        if current is None or current.next is None:
            return current

        # Recursive case: Reverse the rest of the list
        reversed_list = reverse_list_recursive(current.next)

        # Change the next of the current node to reverse its link
        current.next.next = current
        current.next = None

        return reversed_list





if __name__ == "__main__":
    head = LL1.takeInput()

    head = reverse_list_recursive(head)

    while head is not None:
        print(head.data)
        head = head.next