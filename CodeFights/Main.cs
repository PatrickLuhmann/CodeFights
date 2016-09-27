using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CodeFights
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to my CodeFight collection.");
		}

		public static int ClosestSequence2(int[] seq, int[] src)
		{
			// Create a subsequence of src that is the same length as seq.
			// Start with the first N elements of src.
			int[] subseq = new int[seq.Length];
			Array.Copy(src, subseq, seq.Length);

			// Use the difference of the first subseq as the starting point.
			int diff = CalcSeqDiff(seq, subseq);

			// If the two sequences are of the same length, then
			// there is no need to search for a subsequence.
			if (seq.Length != src.Length)
			{
				// Loop through each subsequence of b and calculate the distance from a.

				// Create the initial subsequence.
				int[] seqpos = new int[seq.Length];
				// TODO: There must be a better way to do this.
				for (int i = 0; i < seq.Length; i++)
					seqpos[i] = i;

				bool theend;
				do
				{
					theend = GetNextSubSeq(src, seqpos, subseq);
					int currDiff = CalcSeqDiff(seq, subseq);
					if (currDiff < diff)
						diff = currDiff;
				} while (theend);
			}

			return diff;
		}

		public static int CalcSeqDiff(int[] a, int[] b)
		{
			// If lengths are not the same just return 0.
			if (a.Length != b.Length)
				return 0;

			int diff = 0;
			for (int i = 0; i < a.Length; i++)
			{
				diff += Math.Abs(b[i] - a[i]);
			}

			return diff;
		}

		public static bool GetNextSubSeq(int[] source, int[] seqpos, int[] subseq)
		{
			// If the current subsequence is already the last one, then exit early.
			if (seqpos[0] == source.Length - subseq.Length)
			{
				return false;
			}
			// Start with the last position.
			int i = seqpos.Length - 1;

			// We know this loop will end because we have already checked for the last subsequence.
			while (true)
			{
				// Is the current position at its maximum?
				int posmax = source.Length - subseq.Length + i;
				if (seqpos[i] == posmax)
				{
					// Move back one position and try again.
					i--;
				}
				else
				{
					// Increment this position.
					seqpos[i]++;

					// Increment through the rest of the positions.
					for (int j = i + 1; j < seqpos.Length; j++)
					{
						seqpos[j] = seqpos[j - 1] + 1;
					}

					// Populate the new subsequence.
					for (int j = 0; j < subseq.Length; j++)
					{
						subseq[j] = source[seqpos[j]];
					}

					// We are done
					return true;
				}
			}
		}

		/// <summary>
		/// Create a matrix that holds the differences between two sequences.
		/// This might be helpful in finding the closest subsequence, since
		/// each difference is only calculated once.
		/// </summary>
		/// <param name="a">The first sequence</param>
		/// <param name="b">The second sequence.</param>
		public static void CreateMatrix(int[] a, int[] b)
		{
			int[,] matrix = new int[a.Length, b.Length];

			for (int i = 0; i < a.Length; i++)
			{
				for (int j = 0; j < b.Length; j++)
				{
					matrix[i,j] = Math.Abs(a[i] - b[j]);
				}
			}
		}
	}
}
