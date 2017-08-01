using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var val = Double.MaxValue;
			var var2 = val + 500.3E301;
			Assert.IsTrue(Double.IsPositiveInfinity(var2));
		}
	}
}
