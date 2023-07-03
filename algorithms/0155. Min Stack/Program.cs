/*
Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

Implement the MinStack class:

    MinStack() initializes the stack object.
    void push(int val) pushes the element val onto the stack.
    void pop() removes the element on the top of the stack.
    int top() gets the top element of the stack.
    int getMin() retrieves the minimum element in the stack.

You must implement a solution with O(1) time complexity for each function.

Example 1:

Input
["MinStack","push","push","push","getMin","pop","top","getMin"]
[[],[-2],[0],[-3],[],[],[],[]]

Output
[null,null,null,null,-3,null,0,-2]

Explanation
MinStack minStack = new MinStack();
minStack.push(-2);
minStack.push(0);
minStack.push(-3);
minStack.getMin(); // return -3
minStack.pop();
minStack.top();    // return 0
minStack.getMin(); // return -2

Constraints:

    -231 <= val <= 231 - 1
    Methods pop, top and getMin operations will always be called on non-empty stacks.
    At most 3 * 104 calls will be made to push, pop, top, and getMin.
*/
public class MinStack 
{
  private List<(int Val, int Min)> list;

  public MinStack() 
  {
    list = new();
  }
  
  public void Push(int val) 
  {
    int minVal = val;

    if (list.Count > 0)
      minVal = Math.Min(val, GetMin());

    list.Add((val, minVal));
  }
  
  public void Pop() 
  {
    // O(1) when removing from the end of the list
    list.RemoveAt(list.Count - 1);
  }
  
  public int Top() => list[list.Count - 1].Val; 
  
  public int GetMin() => list[list.Count - 1].Min;
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */