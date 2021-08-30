using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestGameObjectCreation
    {
        // A Test behaves as an ordinary method
        [Test]
        public void EditorTest()
        {
            //Arrange
            var gameObject = new GameObject();
    
            //Act
            //Try to rename the GameObject
            var newGameObjectName = "My game object";
            gameObject.name = newGameObjectName;
    
            //Assert
            //The object has a new name
            Assert.AreEqual(newGameObjectName, gameObject.name);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestGameObjectCreationWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
