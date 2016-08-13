using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cnova.console;
using System.Device.Location;
using System.Linq;

namespace cnova.tests
{
    [TestClass]
    public class FriendFinderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "VisitLocation")]
        public void WhenTryingToGetFriendsWithoutInformingVisitGetError()
        {
            var myFriends = PersonHelper.GetFriends();
            var finder = new FriendFinder(myFriends);
            var friendsClose = finder.GetFriendsCloseToMe();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Friends")]
        public void WhenTryingToGetFriendsWithoutInformingFriendsListGetError()
        {
            var finder = new FriendFinder(null);
            var friendsClose = finder.GetFriendsCloseToMe();
        }
        

        [TestMethod]
        public void ForEachVisitHaveAtLeastOneCloseFriend()
        {
            var myFriends = PersonHelper.GetFriends();

            foreach (var item in myFriends)
            {
                var finder = new FriendFinder(myFriends);
                finder.Visit(item);
                Assert.IsTrue(finder.GetFriendsCloseToMe().Count() >= 1);
            }
        }

    }
}
