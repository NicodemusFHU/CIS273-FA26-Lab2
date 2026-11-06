using System;
namespace KthToLast
{
	public static class LinkedListExtensions
	{
		/// <summary>
		/// Returns the kth-to-last element of the list, treating it as a SINGLY-linked list.
		/// In a singly-linked list each node only knows the node after it, the <c>Next</c> node, so start at
		/// <c>First</c> and move forward with <c>Next</c>. Do not use <c>Last</c> or <c>Previous</c>.
		/// </summary>
		/// <remarks>
		/// k counts backward from the end of the list, starting at 0:
		/// k = 0 is the last element (the tail), k = 1 is the element directly before the tail, and so on.
		/// </remarks>
		/// <example>
		/// <code>
		/// // list: 1 -> 2 -> 3 -> 4 -> 5
		/// list.KthToLastSinglyLinked(0); // 5 (the tail)
		/// list.KthToLastSinglyLinked(1); // 4
		/// list.KthToLastSinglyLinked(4); // 1 (the head)
		/// </code>
		/// </example>
		/// <typeparam name="T">The type of the values stored in the list.</typeparam>
		/// <param name="linkedList">The list to search.</param>
		/// <param name="k">How many positions back from the last element to go (0 = last element).</param>
		/// <returns>The value stored k positions before the end of the list.</returns>
		/// <exception cref="IndexOutOfRangeException">
		/// Thrown when k is negative or too large, that is, when there is no element k positions
		/// before the end. For a list of 5 elements, valid k values are 0 through 4.
		/// An empty list has no valid k values.
		/// </exception>

		public static T KthToLastSinglyLinked<T>(this LinkedList<T> linkedList, int k)
		{
			if(k < 0 || k > linkedList.Count - 1 || linkedList.Count == 0)
			{
				throw new IndexOutOfRangeException();
			}

			int nodesToMove = linkedList.Count - (1+k);
			LinkedListNode<T> currentNode = linkedList.First!;
			while (nodesToMove > 0)
			{
				currentNode = currentNode.Next!;
				nodesToMove--;
			}
			
			return currentNode.Value;
		}

        /// <summary>
        /// Returns the kth-to-last element of the list, treating it as a DOUBLY-linked list.
        /// In a doubly-linked list each node knows both its neighbors, so you may start at
        /// <c>Last</c> and move backward with <c>Previous</c>.
        /// </summary>
        /// <remarks>
        /// k counts backward from the end of the list, starting at 0:
        /// k = 0 is the last element (the tail), k = 1 is the element directly before the tail, and so on.
        /// </remarks>
        /// <example>
        /// <code>
        /// // list: 1 -> 2 -> 3 -> 4 -> 5
        /// list.KthToLastDoublyLinked(0); // 5 (the tail)
        /// list.KthToLastDoublyLinked(1); // 4
        /// list.KthToLastDoublyLinked(4); // 1 (the head)
        /// </code>
        /// </example>
        /// <typeparam name="T">The type of the values stored in the list.</typeparam>
        /// <param name="linkedList">The list to search.</param>
        /// <param name="k">How many positions back from the last element to go (0 = last element).</param>
        /// <returns>The value stored k positions before the end of the list.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when k is negative or too large, that is, when there is no element k positions
        /// before the end. For a list of 5 elements, valid k values are 0 through 4.
        /// An empty list has no valid k values.
        /// </exception>

        public static T KthToLastDoublyLinked<T>(this LinkedList<T> linkedList, int k)
        {
			if(k < 0 || k > linkedList.Count - 1 || linkedList.Count == 0)
			{
				throw new IndexOutOfRangeException();
			}

			var currentNode = linkedList.Last;
			while(k > 0)
			{
				currentNode = currentNode?.Previous;
				k--;
			}

			return currentNode.Value;
        }
    }
}
