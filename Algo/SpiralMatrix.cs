/*
Given an m x n matrix, return all elements of the matrix in spiral order.

Example 1:
Input: matrix = [[1, 2, 3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]

Example 2:
Input: matrix = [[1, 2, 3, 4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]

Constraints:
m == matrix.length
n == matrix[i].length
1 <= m, n <= 10
- 100 <= matrix[i][j] <= 100
*/

/*
Please implement the SpiralOrder method according to the description.
The correctness of the implementation will be validated with tests
once you send back your solution.
*/

using System.Collections.Generic;

namespace Algo
{
    public class SpiralMatrix
    {
        public IList<int> SpiralOrder(int[,] matrix)
        {
            int m = matrix.GetLength(0), n = matrix.GetLength(1);
            int i, k = 0, l = 0;
            List<int> result = new List<int>();
            while (k < m && l < n)
            {
                for (i = l; i < n; ++i)
                {

                    result.Add(matrix[k, i]);
                }
                k++;
                for (i = k; i < m; ++i)
                {
                    result.Add(matrix[i, n - 1]);
                }
                n--;
                if (k < m)
                {
                    for (i = n - 1; i >= l; --i)
                    {
                        result.Add(matrix[m - 1, i]);
                    }
                    m--;
                }
                if (l < n)
                {
                    for (i = m - 1; i >= k; --i)
                    {
                        result.Add(matrix[i, l]);
                    }
                    l++;
                }
            }
            return result;
        }
    }
}


