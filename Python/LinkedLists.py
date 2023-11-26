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