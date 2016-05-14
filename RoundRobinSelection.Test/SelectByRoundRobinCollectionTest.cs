using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoundRobinSelection.Extension;

namespace RoundRobinSelection.Test
{
    [TestClass]
    public class SelectByRoundRobinCollectionTest
    {
        private readonly IEnumerable<Person> _people = Person.GetPeople();

        [TestMethod]
        public void ShouldSelectByRoundRobinCollectionByPersonAgeAndIndex()
        {
            int? lastSelectedIndex = null;

            var selectedElement = _people.SelectByRoundRobin(c => c.Age, lastSelectedIndex);

            Assert.AreEqual(28, selectedElement.Item1.Age);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(0, lastSelectedIndex);

            // Next element

            selectedElement = _people.SelectByRoundRobin(c => c.Age, lastSelectedIndex);

            Assert.AreEqual(29, selectedElement.Item1.Age);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(1, lastSelectedIndex);

            // Next element

            selectedElement = _people.SelectByRoundRobin(c => c.Age, lastSelectedIndex);

            Assert.AreEqual(32, selectedElement.Item1.Age);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(2, lastSelectedIndex);

            // Next element

            selectedElement = _people.SelectByRoundRobin(c => c.Age, lastSelectedIndex);

            Assert.AreEqual(28, selectedElement.Item1.Age);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(0, lastSelectedIndex);

            // Next element

            selectedElement = _people.SelectByRoundRobin(c => c.Age, lastSelectedIndex);

            Assert.AreEqual(29, selectedElement.Item1.Age);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(1, lastSelectedIndex);

            // Next element

            selectedElement = _people.SelectByRoundRobin(c => c.Age, lastSelectedIndex);

            Assert.AreEqual(32, selectedElement.Item1.Age);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(2, lastSelectedIndex);
        }

        [TestMethod]
        public void ShouldSelectByRoundRobinCollectionByPersonLastNameAndIndex()
        {
            int? lastSelectedIndex = null;

            var selectedElement = _people.SelectByRoundRobin(c => c.LastName, lastSelectedIndex);

            Assert.AreEqual("Cunningham", selectedElement.Item1.LastName);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(0, lastSelectedIndex);

            // Next element

            selectedElement = _people.SelectByRoundRobin(c => c.LastName, lastSelectedIndex);

            Assert.AreEqual("Poppy", selectedElement.Item1.LastName);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(1, lastSelectedIndex);

            // Next element

            selectedElement = _people.SelectByRoundRobin(c => c.LastName, lastSelectedIndex);

            Assert.AreEqual("Smith", selectedElement.Item1.LastName);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(2, lastSelectedIndex);

            // Next element

            selectedElement = _people.SelectByRoundRobin(c => c.LastName, lastSelectedIndex);

            Assert.AreEqual("Cunningham", selectedElement.Item1.LastName);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(0, lastSelectedIndex);

            // Next element

            selectedElement = _people.SelectByRoundRobin(c => c.LastName, lastSelectedIndex);

            Assert.AreEqual("Poppy", selectedElement.Item1.LastName);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(1, lastSelectedIndex);

            // Next element

            selectedElement = _people.SelectByRoundRobin(c => c.LastName, lastSelectedIndex);

            Assert.AreEqual("Smith", selectedElement.Item1.LastName);

            lastSelectedIndex = selectedElement.Item2;

            Assert.AreEqual(2, lastSelectedIndex);
        }

        [TestMethod]
        public void ShouldSelectByRoundRobinFromPriorElementCollectionByPersonLastName()
        {
            var selectedElement = _people.SelectByRoundRobinFromPriorElement(c => c.LastName, null);

            Assert.AreEqual("Cunningham", selectedElement.LastName);

            // Next element

            selectedElement = _people.SelectByRoundRobinFromPriorElement(c => c.LastName, selectedElement);

            Assert.AreEqual("Poppy", selectedElement.LastName);

            // Next element

            selectedElement = _people.SelectByRoundRobinFromPriorElement(c => c.LastName, selectedElement);

            Assert.AreEqual("Smith", selectedElement.LastName);

            // Next element

            selectedElement = _people.SelectByRoundRobinFromPriorElement(c => c.LastName, null);

            Assert.AreEqual("Cunningham", selectedElement.LastName);

            // Next element

            selectedElement = _people.SelectByRoundRobinFromPriorElement(c => c.LastName, selectedElement);

            Assert.AreEqual("Poppy", selectedElement.LastName);

            // Next element

            selectedElement = _people.SelectByRoundRobinFromPriorElement(c => c.LastName, selectedElement);

            Assert.AreEqual("Smith", selectedElement.LastName);
        }
    }
}
