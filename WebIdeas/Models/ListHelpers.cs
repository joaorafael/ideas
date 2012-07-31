using System.Collections.Generic;

namespace WebIdeas.Models
{
    public class ListHelpers
    {
        public static bool TestEqualList<T>(IList<T> thisList, IList<T> otherList)
        {
            if (thisList == null)
            {
                if (otherList != null)
                {
                    return false;
                }
            }
            else
            {
                if (otherList == null)
                {
                    return false;
                }
                if (thisList.Count == otherList.Count)
                {
                    for (var i = 0; i < otherList.Count; i++)
                    {
                        var thisOne = thisList[i];
                        var otherOne = otherList[i];

                        if (thisOne != null)
                        {
                            if (otherOne == null) return false;
                            if (!(thisOne.Equals(otherOne)))
                                return false;
                        }
                        else
                        {
                            if (otherOne != null)
                                return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}