namespace ReverseFirstK;

public class Program
{
     public static void Main(string[] args)
     {
     }

     /// <summary>
     /// Write a method void ReverseFirstK(Queue q, int k) that reverses the first k elements of the given queue. 
     /// You may only use stacks and queues (NOT deques) to do this. 
     /// </summary>
     /// <typeparam name="T"></typeparam>
     /// <param name="queue"></param>
     /// <param name="k"></param>
     /// <returns></returns>
     public static void ReverseFirstK<T>(Queue<T> queue, int k)
     {
          ArgumentNullException.ThrowIfNull(queue);
          if (k < 0)
          {
               throw new ArgumentException();
          }

          int elementsToReverse = Math.Min(k, queue.Count);
          Stack<T> stack = new();

          for (int i = 0; i < elementsToReverse; i++)
          {
               stack.Push(queue.Dequeue());
          }

          while (stack.Count > 0)
          {
               queue.Enqueue(stack.Pop());
          }

          int elementsToMove = queue.Count - elementsToReverse;
          for (int i = 0; i < elementsToMove; i++)
          {
               queue.Enqueue(queue.Dequeue());
          }
     }
}

