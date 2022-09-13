using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace SmalBox
{
    /// <summary>
    /// 字符替换类
    /// </summary>
    public class ReplaceUtl : Singleton<ReplaceUtl>
    {
        public string Replace(string value, params object[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null)
                    continue;
                value = value.Replace("{" + i + "}", args[i].ToString());
            }
            return value;
        }

        private static Regex rgx = new Regex(@"\r*\n");
        public string ReplaceN(string value, string replaceToStr = "")
        {
            return rgx.Replace(value, replaceToStr);
        }

        private static Regex rgxR = new Regex(@"\r");
        public string ReplaceR(string value, string replaceToStr = "")
        {
            return rgxR.Replace(value, replaceToStr);
        }

        private char[] arrarySplit = new char[] { '#' };
        private char[] posSplit = new char[] { ';', '|' };
        private char[] v2Split = new char[] { ',' };
        private char[] v2Symbol = new char[] { '(', ')' };
		/// <summary>
		/// 转换范围数组
		/// </summary>
		/// <param name="strRectArrary"></param>
		/// <returns></returns>
		public List<Rect> PraseRectArrary(string strRectArrary)
		{
			List<Rect> result = null;
			if (!string.IsNullOrEmpty(strRectArrary))
			{
				result = new List<Rect>();
				string[] strRects = strRectArrary.Split(arrarySplit, System.StringSplitOptions.RemoveEmptyEntries);
				foreach (var strRect in strRects)
				{
					if(ParseRect(strRect, out Rect rect))
					{
						result.Add(rect);
					}
				}
			}

			return result;
		}

		/// <summary>
		/// 转换范围
		/// </summary>
		/// <param name="strRect"></param>
		/// <param name="rect"></param>
		/// <returns></returns>
		public bool ParseRect(string strRect, out Rect rect)
		{
			rect = Rect.zero;
			bool suc = !string.IsNullOrEmpty(strRect);
			if (suc)
			{
				string[] strPosSize = strRect.Split(posSplit, System.StringSplitOptions.RemoveEmptyEntries);
				ParseRect(strPosSize[0], strPosSize[1], out rect);
			}
			return suc;
		}

		public bool ParseRect(string strStart, string strEnd, out Rect rect)
		{
			rect = Rect.zero;
			bool suc = ParsePos(strStart, out Vector2 pos);
			if (suc)
			{
				suc = ParsePos(strEnd, out Vector2 end);
				if (suc)
				{
					end += Vector2.one;//范围最大值不包含这里扩大1
					rect = new Rect(pos, end - pos);
				}
			}
			return suc;
		}

		/// <summary>
		/// 字符串转v2
		/// </summary>
		/// <param name="strPos"></param>
		/// <param name="pos"></param>
		/// <returns></returns>
		public bool ParsePos(string strPos, out Vector2 pos)
		{
			pos = Vector2.zero;
			if (!string.IsNullOrEmpty(strPos))
			{
				int removeIdx;
				while ((removeIdx = strPos.IndexOfAny(v2Symbol)) > -1)
				{
					strPos = strPos.Remove(removeIdx, 1);
				}
				string[] strPoss = strPos.Split(v2Split, System.StringSplitOptions.RemoveEmptyEntries);
				pos = new Vector2(float.Parse(strPoss[0]), float.Parse(strPoss[1]));
				return true;
			}

			return false;
		}
	}
}