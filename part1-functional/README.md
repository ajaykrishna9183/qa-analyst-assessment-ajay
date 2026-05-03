# QA Analyst Assessment

This repository contains solutions for the take-home assessment, divided into two parts:

- Part 1: Functional Programming
- Part 2: API Testing

---

##  Project Structure

qa-analyst-assessment/

├── part1-functional/  
│   ├── RemoveDuplicates.cs  
│   └── README.md  
│  
└── part2-api-testing/  
    ├── ApiTests.cs  
    └── README.md  

---

# Part 1: Functional Programming

##  Problem
Write a pure function to remove duplicates from a list while preserving the order of first occurrences.

Example:
Input:  [1, 2, 3, 2, 4, 1, 5]  
Output: [1, 2, 3, 4, 5]

---

##  Approach

I have implemented two approaches:

### 1. Brute Force Approach
- Used nested loops to check if an element already exists in the result list
- For each element, compared it with previously added elements
- If not found, added to result

**Time Complexity:** O(n²)  
**Space Complexity:** O(n)

---

### 2. Optimal Approach (Using HashSet)
- Used a HashSet to track already seen elements
- Since HashSet lookup is O(1), duplicate checking is efficient
- Maintained order using a separate result list

**Time Complexity:** O(n)  
**Space Complexity:** O(n)

---

## ⚙️ Functional Programming Principles Followed

- Pure function (same input → same output)
- No modification of original input
- Returned a new list
- Used clean and readable logic

---

##  Test Cases

```csharp
[1, 2, 3, 2, 4, 1, 5] → [1, 2, 3, 4, 5]
[1, 1, 1]             → [1]
[]                    → []