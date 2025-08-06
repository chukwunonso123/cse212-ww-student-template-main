public static class Trees
{
    /// <summary>
    /// Given a sorted list (sortedNumbers), create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Recursively insert the middle element of the array/subarray to create a balanced BST.
    /// </summary>
    /// <param name="sortedNumbers">Input array that is already sorted</param>
    /// <param name="first">Start index of current subarray</param>
    /// <param name="last">End index of current subarray</param>
    /// <param name="bst">Binary Search Tree to insert into</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last) return; // Base case: no elements to insert

        int mid = (first + last) / 2; // Find the middle index

        bst.Insert(sortedNumbers[mid]); // Insert middle element into BST

        // Recursively insert left and right halves
        InsertMiddle(sortedNumbers, first, mid - 1, bst);
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
