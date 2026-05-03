# Part 1: Functional Programming

##  Overview
This part focuses on writing a function to remove duplicates from a list while keeping the original order.  
The solution is implemented in C# and follows a pure function approach.

---

##  Problem
Given a list of numbers, return a new list with duplicates removed while preserving the order of first occurrences.

Example:  
Input:  [1, 2, 3, 2, 4, 1, 5]  
Output: [1, 2, 3, 4, 5]

---

##  Approach

### 1. Brute Force Approach
- Used nested loops to check if an element already exists in the result list  
- For each item, compared it with elements already added  
- If not found, added it to the result  

**Time Complexity:** O(n²)  
**Space Complexity:** O(n)

---

### 2. Optimal Approach (Using HashSet)
- Used a HashSet to keep track of elements already seen  
- Since lookup in HashSet is fast, it avoids repeated comparisons  
- Maintained order using a separate result list  

**Time Complexity:** O(n)  
**Space Complexity:** O(n)

---

##  Key Points
- The function does not modify the original input  
- A new list is returned (pure function)  
- Order of elements is preserved  
- Duplicate values are removed correctly  

---

##  Test Cases

```csharp
[1, 2, 3, 2, 4, 1, 5] -> [1, 2, 3, 4, 5]
[1, 1, 1]             -> [1]
[]                    -> []