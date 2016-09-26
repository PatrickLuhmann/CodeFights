using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFights.Tests
{
	[TestClass()]
	public class ProgramTests
	{
		[TestMethod()]
		public void ClosestSequence2Test_1Of1Same()
		{
			int[] a = new int[] { 1 };
			int[] b = new int[] { 1 };

			Assert.AreEqual(0, Program.ClosestSequence2(a, b));
		}

		[TestMethod()]
		public void ClosestSequence2Test_5Of5Same()
		{
			int[] a = new int[] { 1, 2, 3, 4, 5 };
			int[] b = new int[] { 1, 2, 3, 4, 5 };

			Assert.AreEqual(0, Program.ClosestSequence2(a, b));
		}

		[TestMethod()]
		public void ClosestSequence2Test_1Of1Different()
		{
			int[] a = new int[] { 1 };
			int[] b = new int[] { 7 };

			Assert.AreEqual(6, Program.ClosestSequence2(a, b));
		}

		[TestMethod()]
		public void ClosestSequence2Test_One()
		{
			int[] a = new int[] { 1, 2, 6 };
			int[] b = new int[] { 0, 1, 3, 4, 5 };

			Assert.AreEqual(2, Program.ClosestSequence2(a, b));

			//Assert.Fail();
		}

		[TestMethod()]
		public void GetNextSubSeqTest_OneElement()
		{
			int[] src = new int[] { 1 };

			int[] pos_b = new int[] { 0 };
			int[] pos_a = new int[pos_b.Length];
			pos_b.CopyTo(pos_a, 0);

			int[] subseq_b = new int[] { 123 };
			int[] subseq_a = new int[subseq_b.Length];
			subseq_b.CopyTo(subseq_a, 0);

			bool act;

			act = Program.GetNextSubSeq(src, pos_a, subseq_b);

			// pos is already the last sequence, so it should return false.
			Assert.IsFalse(act);

			// And pos should not have changed.
			Assert.IsTrue(pos_b.SequenceEqual(pos_a));

			// And subseq should not have changed.
			Assert.IsTrue(subseq_b.SequenceEqual(subseq_a));
		}

		[TestMethod()]
		public void GetNextSubSeqTest_TwoElementsBeginning()
		{
			int[] src = new int[] { 1, 2 };

			int[] pos = new int[] { 0 };
			int[] pos_exp = new int[pos.Length];

			int[] subseq = new int[] { 123 };
			int[] subseq_exp = new int[subseq.Length];

			bool act;

			// Set up expected values.

			// Pos will move one place.
			pos.CopyTo(pos_exp, 0);
			pos_exp[0] = 1;

			// The corresponding subsequence will be {2}.
			subseq.CopyTo(subseq_exp, 0);
			subseq_exp[0] = 2;

			// Execute method under test.
			act = Program.GetNextSubSeq(src, pos, subseq);

			// Compare actual to expected results.

			// pos is not the last, so it should return true.
			Assert.IsTrue(act);

			// Verify pos has changed.
			Assert.IsTrue(pos_exp.SequenceEqual(pos));

			// Verify subseq has changed.
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));
		}

		[TestMethod()]
		public void GetNextSubSeqTest_TwoElementsEnd()
		{
			int[] src = new int[] { 1, 2 };

			int[] pos = new int[] { 1 };
			int[] pos_exp = new int[pos.Length];

			int[] subseq = new int[] { 123 };
			int[] subseq_exp = new int[subseq.Length];

			bool act;

			// Set up expected values.

			// Pos will not move.
			pos.CopyTo(pos_exp, 0);

			// Subseq will not change.
			subseq.CopyTo(subseq_exp, 0);

			// Execute method under test.
			act = Program.GetNextSubSeq(src, pos, subseq);

			// Compare actual to expected results.

			// pos is the last, so it should return false.
			Assert.IsFalse(act);

			// Verify pos.
			Assert.IsTrue(pos_exp.SequenceEqual(pos));

			// Verify subseq.
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));
		}

		[TestMethod()]
		public void GetNextSubSeqTest_OneOfThree()
		{
			int[] src = new int[] { 1, 2, 3 };

			int[] pos = new int[] { 0 };
			int[] pos_exp = new int[pos.Length];

			int[] subseq = new int[] { 123 };
			int[] subseq_exp = new int[subseq.Length];

			bool act;

			// First call.

			// Set up expected values.
			pos.CopyTo(pos_exp, 0);
			pos_exp[0] = 1;
			subseq.CopyTo(subseq_exp, 0);
			subseq_exp[0] = 2;

			// Execute method under test.
			act = Program.GetNextSubSeq(src, pos, subseq);

			// Compare actual to expected results.
			Assert.IsTrue(act);
			Assert.IsTrue(pos_exp.SequenceEqual(pos));
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));

			// Second call.

			// Set up expected values.
			pos_exp[0] = 2;
			subseq[0] = 456;
			subseq_exp[0] = 3;

			// Execute method under test.
			act = Program.GetNextSubSeq(src, pos, subseq);

			// Compare actual to expected results.
			Assert.IsTrue(act);
			Assert.IsTrue(pos_exp.SequenceEqual(pos));
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));

			// Third call is at the end.

			// Expected values won't change, but still need to make sure
			// subseq doesn't change.
			subseq_exp[0] = subseq[0] = 789;

			// Execute method under test.
			act = Program.GetNextSubSeq(src, pos, subseq);

			// Compare actual to expected results.
			Assert.IsFalse(act);
			Assert.IsTrue(pos_exp.SequenceEqual(pos));
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));
		}

		[TestMethod()]
		public void GetNextSubSeqTest_TwoOfThree()
		{
			int[] src = new int[] { 1, 2, 3 };

			int[] pos = new int[] { 0, 1 };
			int[] pos_exp = new int[pos.Length];

			int[] subseq = new int[] { 123, 456 };
			int[] subseq_exp = new int[subseq.Length];

			bool act;

			// First call.

			// Set up expected values.
			pos.CopyTo(pos_exp, 0);
			pos_exp[1] = 2;
			subseq.CopyTo(subseq_exp, 0);
			subseq_exp[0] = 1;
			subseq_exp[1] = 3;

			// Execute method under test.
			act = Program.GetNextSubSeq(src, pos, subseq);

			// Compare actual to expected results.
			Assert.IsTrue(act);
			Assert.IsTrue(pos_exp.SequenceEqual(pos));
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));

			// Second call.

			// Set up expected values.
			pos_exp[0] = 1;
			pos_exp[1] = 2;
			subseq[0] = 777;
			subseq[0] = 888;
			subseq_exp[0] = 2;
			subseq_exp[1] = 3;

			// Execute method under test.
			act = Program.GetNextSubSeq(src, pos, subseq);

			// Compare actual to expected results.
			Assert.IsTrue(act);
			Assert.IsTrue(pos_exp.SequenceEqual(pos));
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));

			// Third call is at the end.

			// Expected values won't change, but still need to make sure
			// subseq doesn't change.
			subseq_exp[0] = subseq[0] = 999;

			// Execute method under test.
			act = Program.GetNextSubSeq(src, pos, subseq);

			// Compare actual to expected results.
			Assert.IsFalse(act);
			Assert.IsTrue(pos_exp.SequenceEqual(pos));
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));
		}

		[TestMethod()]
		public void GetNextSubSeqTest_ThreeOfSix()
		{
			int[] src = new int[] { 1, 1, 2, 3, 5, 8 };
			int[] pos = new int[] { 0, 1, 2 };
			int[] subseq = new int[] { 123, 456, 789 };
			bool act;

			// The sequence of pos is
			//   {0, 1, 2} - initial
			//   {0, 1, 3} - test A
			//   {0, 1, 4}
			//   {0, 1, 5}
			//   {0, 2, 3} - test B
			//   {0, 2, 4}
			//   {0, 2, 5}
			//   {0, 3, 4}
			//   {0, 3, 5}
			//   {0, 4, 5}
			//   {1, 2, 3} - test C
			//   {1, 2, 4}
			//   {1, 2, 5}
			//   {1, 3, 4}
			//   {1, 3, 5}
			//   {1, 4, 5}
			//   {2, 3, 4} - test D
			//   {2, 3, 5}
			//   {2, 4, 5}
			//   {3, 4, 5} - test E (last)

			// A: Do one iteration and check.
			int[] pos_exp = { 0, 1, 3 };
			int[] subseq_exp = { 1, 1, 3 };
			act = Program.GetNextSubSeq(src, pos, subseq);
			// Compare actual to expected results.
			Assert.IsTrue(act);
			Assert.IsTrue(pos_exp.SequenceEqual(pos));
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));

			// B: Do three more iterations and check.
			pos_exp = new int[] { 0, 2, 3 };
			subseq_exp = new int[] { src[pos_exp[0]], src[pos_exp[1]], src[pos_exp[2]] };
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			// Compare actual to expected results.
			Assert.IsTrue(act);
			Assert.IsTrue(pos_exp.SequenceEqual(pos));
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));

			// C: Do six more iterations and check.
			pos_exp = new int[] { 1, 2, 3 };
			subseq_exp = new int[] { src[pos_exp[0]], src[pos_exp[1]], src[pos_exp[2]] };
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			// Compare actual to expected results.
			Assert.IsTrue(act);
			Assert.IsTrue(pos_exp.SequenceEqual(pos));
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));

			// D: Do six more iterations and check.
			pos_exp = new int[] { 2, 3, 4 };
			subseq_exp = new int[] { src[pos_exp[0]], src[pos_exp[1]], src[pos_exp[2]] };
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			// Compare actual to expected results.
			Assert.IsTrue(act);
			Assert.IsTrue(pos_exp.SequenceEqual(pos));
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));

			// E: Do three more iterations and check.
			pos_exp = new int[] { 3, 4, 5 };
			subseq_exp = new int[] { src[pos_exp[0]], src[pos_exp[1]], src[pos_exp[2]] };
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			act = Program.GetNextSubSeq(src, pos, subseq);
			// Compare actual to expected results.
			Assert.IsTrue(act);
			Assert.IsTrue(pos_exp.SequenceEqual(pos));
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));

			// F: At the end.
			pos_exp = new int[] { 3, 4, 5 };
			subseq = new int[] { 11, 22, 33 };
			subseq_exp = new int[] { subseq[0], subseq[1], subseq[2] };
			act = Program.GetNextSubSeq(src, pos, subseq);
			// Compare actual to expected results.
			Assert.IsFalse(act);
			Assert.IsTrue(pos_exp.SequenceEqual(pos));
			Assert.IsTrue(subseq_exp.SequenceEqual(subseq));
		}

		[TestMethod()]
		public void CalcSeqDiffTest_Basic()
		{
			int act, exp;
			int[] a, b;

			a = new int[] { 1, 2, 3 };
			b = new int[] { 11, 22, 33 };
			exp = 10 + 20 + 30;
			act = Program.CalcSeqDiff(a, b);
			Assert.AreEqual(exp, act);

			a = new int[] { 1000, 500, 333 };
			b = new int[] { -17, -123, -999 };
			exp = 1017 + 623 + 1332;
			act = Program.CalcSeqDiff(a, b);
			Assert.AreEqual(exp, act);

			a = new int[] { 1000, 1000, 1000 };
			b = new int[] { 1000, 1000, 1000 };
			exp = 0;
			act = Program.CalcSeqDiff(a, b);
			Assert.AreEqual(exp, act);

			a = new int[] { -1000, -1000, -1000 };
			b = new int[] { -1000, -1000, -1000 };
			exp = 0;
			act = Program.CalcSeqDiff(a, b);
			Assert.AreEqual(exp, act);

			a = new int[] { 1000, -1000, 1000 };
			b = new int[] { -1000, 1000, -1000 };
			exp = 2000 + 2000 + 2000;
			act = Program.CalcSeqDiff(a, b);
			Assert.AreEqual(exp, act);
		}
	}
}