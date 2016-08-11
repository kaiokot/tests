using System;

namespace cnova.console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var myFriends = PersonHelper.GetFriends();

            foreach (var friend in myFriends)
            {
                var finder = new FriendFinder(myFriends);

                finder.Visit(friend);

                var friendsClose = finder.GetFriendsCloseToMe();

                Console.WriteLine($"Friends close to { friend.Name } (in { finder.GetDefaultDistanceInMeters()} mts) : " + Environment.NewLine);

                friendsClose.ForEach(_ => Console.Write(_.Name + Environment.NewLine));

                Console.WriteLine(" ------------------------------------------------------------------ ");

            }

            Console.ReadKey();
        }
    }
}
