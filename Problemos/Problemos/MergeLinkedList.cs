namespace Problemos;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}


public class MergeLinkedList
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        var numberOfLists = lists.Length;

        if (numberOfLists == 0)
            return null;

        if (numberOfLists == 1)
            return lists[0];

        for (var i = 0; i < numberOfLists - 1; i++)
        {
            lists[0] = SortTwoLists(lists[0], lists[i + 1]);
        }

        return lists[0];
    }

    private ListNode SortTwoLists(ListNode listOne, ListNode listTwo)
    {
        if (listOne == null)
            return listTwo;

        if (listTwo == null)
            return listOne;

        var leftIsLower = listOne.val < listTwo.val;
        var head = leftIsLower ? listOne : listTwo;
        head.next = leftIsLower ? SortTwoLists(listOne.next, listTwo) : SortTwoLists(listOne, listTwo.next);
        return head;
    }
}
