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


if __name__ == "__main__":
    head = LL1.takeInput()

    head = reverseLL(head)

    while head is not None:
        print(head.data)
        head = head.next