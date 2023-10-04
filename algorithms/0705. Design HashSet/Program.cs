/*
Design a HashSet without using any built-in hash table libraries.

Implement MyHashSet class:

    void add(key) Inserts the value key into the HashSet.
    bool contains(key) Returns whether the value key exists in the HashSet or not.
    void remove(key) Removes the value key in the HashSet. If key does not exist in the HashSet, do nothing.

Example 1:

Input
["MyHashSet", "add", "add", "contains", "contains", "add", "contains", "remove", "contains"]
[[], [1], [2], [1], [3], [2], [2], [2], [2]]
Output
[null, null, null, true, false, null, true, null, false]

Explanation
MyHashSet myHashSet = new MyHashSet();
myHashSet.add(1);      // set = [1]
myHashSet.add(2);      // set = [1, 2]
myHashSet.contains(1); // return True
myHashSet.contains(3); // return False, (not found)
myHashSet.add(2);      // set = [1, 2]
myHashSet.contains(2); // return True
myHashSet.remove(2);   // set = [1]
myHashSet.contains(2); // return False, (already removed)

Constraints:

    0 <= key <= 10^6
    At most 10^4 calls will be made to add, remove, and contains.
*/
// Time complexity: O(1)
// Space complexity: O(10^4)
public class MyHashSet 
{
  private List<int>[] array;
  
  private int getIndex(int key)
  {
    return key % array.Length;
  }
  
  public MyHashSet() 
  {
    array = new List<int>[40000];
  }
  
  public void Add(int key) 
  {
    int i = getIndex(key);
    if (array[i] == null)
      array[i] = new List<int>();
    if (!array[i].Contains(key))
      array[i].Add(key);
  }
  
  public void Remove(int key) 
  {
    int i = getIndex(key);
    if (array[i] != null)
      array[i].Remove(key);
  }
  
  public bool Contains(int key) 
  {
    int i = getIndex(key);
    if (array[i] != null)
      return array[i].Contains(key);

    return false;
  }
}
/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */