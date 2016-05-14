using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundRobinSelection.Extension;

namespace RoundRobinSelection.Test
{
    [TestClass]
    public class SelectByRoundRobinArrayTest
    {
        private readonly string[] _colorNames = { "orange", "blue", "green" };

        [TestMethod]
        public void ShouldSelectByRoundRobinArrayByIndex()
        {
            int? lastSelectedIndex = null;

            var selectedElement = _colorNames.SelectByRoundRobin(c => c, lastSelectedIndex);

            Assert.AreEqual("blue", selectedElement.Item1);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(0, lastSelectedIndex);

            // Next element

            selectedElement = _colorNames.SelectByRoundRobin(c => c, lastSelectedIndex);

            Assert.AreEqual("green", selectedElement.Item1);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(1, lastSelectedIndex);

            // Next element

            selectedElement = _colorNames.SelectByRoundRobin(c => c, lastSelectedIndex);

            Assert.AreEqual("orange", selectedElement.Item1);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(2, lastSelectedIndex);

            // Next element

            selectedElement = _colorNames.SelectByRoundRobin(c => c, lastSelectedIndex);

            Assert.AreEqual("blue", selectedElement.Item1);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(0, lastSelectedIndex);

            // Next element

            selectedElement = _colorNames.SelectByRoundRobin(c => c, lastSelectedIndex);

            Assert.AreEqual("green", selectedElement.Item1);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(1, lastSelectedIndex);

            // Next element

            selectedElement = _colorNames.SelectByRoundRobin(c => c, lastSelectedIndex);

            Assert.AreEqual("orange", selectedElement.Item1);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(2, lastSelectedIndex);
        }
    }
}
