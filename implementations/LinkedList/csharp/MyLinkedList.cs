namespace LinkedList
{
    public class MyNode
    {
        public int val;
        public MyNode next;

        public MyNode(int val)
        {
            this.val = val;
        }

        public MyNode()
        {

        }
    }

    public class MyLinkedList
    {

        private MyNode _head;

        public MyLinkedList()
        {

        }

        public int Get(int index)
        {

            if (index < 0)
                return -1;

            //1 -> 2 -> 3 -> 4 -> null
            var headPtr = _head;
            for (int i = 0; i < index; i++)
            {
                if (headPtr.next == null)
                    return -1;

                headPtr = headPtr.next;
            }

            if (headPtr == null)
                return -1;

            return headPtr.val;
        }

        public void AddAtHead(int val)
        {
            var newNode = new MyNode(val);
            newNode.next = _head;
            _head = newNode;
        }

        public void AddAtTail(int val)
        {

            if (_head == null)
            {
                _head = new MyNode(val);
                return;
            }

            var headPtr = _head;
            // 1 -> 2 -> 3 -> 4 -> null
            while (headPtr.next != null)
            {
                headPtr = headPtr.next;
            }

            headPtr.next = new MyNode(val);
        }

        public void AddAtIndex(int index, int val)
        {

            if (index == 0)
            {
                AddAtHead(val);
                return;
            }

            var headPtr = _head;

            // 1 -> 3 -> null


            for (int i = 0; i < index - 1; i++)
            {
                if (headPtr == null)
                    return;

                headPtr = headPtr.next;
            }

            if (headPtr == null)
                return;

            // 1 -> 0 -> 2 -> 3 -> null
            // index: 1, value: 0

            var temp = headPtr.next;
            headPtr.next = new MyNode(val);
            headPtr.next.next = temp;
        }

        public void DeleteAtIndex(int index)
        {

            if (_head == null)
                return;

            if (index == 0)
            {
                _head = _head.next;
                return;
            }

            // 1 -> 2 -> 3 -> 4 -> null
            var headPtr = _head;

            for (int i = 0; i < index - 1; i++)
            {
                if (headPtr.next == null)
                    break;

                headPtr = headPtr.next;
            }

            if (headPtr.next == null)
            {
                headPtr = null;
                return;
            }

            headPtr.next = headPtr.next.next;
        }
    }
}