using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LRSkipAsync;

namespace ChkNameAsync
{
    public class CS_ChkNameAsync
    {
        #region 共有領域
        CS_LRskipAsync lrskip;      // 両側余白情報を削除

        private static String _wbuf;       // ソース情報
        private static Boolean _empty;     // ソース情報有無
        public String Wbuf
        {
            get
            {
                return (_wbuf);
            }
            set
            {
                _wbuf = value;
                if (_wbuf == null)
                {   // 設定情報は無し？
                    _empty = true;
                }
                else
                {   // 整形処理を行う
                    // 不要情報削除
                    if (lrskip == null)
                    {   // 未定義？
                        lrskip = new CS_LRskipAsync();
                    }
                    lrskip.ExecAsync(_wbuf);
                    _wbuf = lrskip.Wbuf;

                    // 作業の為の下処理
                    if (_wbuf.Length == 0 || _wbuf == null)
                    {   // バッファー情報無し
                        // _wbuf = null;
                        _empty = true;
                    }
                    else
                    {
                        _empty = false;
                    }
                }
            }
        }
        private static String _result;     // [Namespace]ＬＢＬ情報
        public String Result
        {
            get
            {
                return (_result);
            }
            set
            {
                _result = value;
            }
        }

        // 予約語：「ＮａｍｅＳｐａｃｅ」
        const int RSV_NONE = 0;     // 未定義
        const int RSV_OTHER = 6;    // 予約語６：その他
                                    //        const string RSV_KEYWORD = "namespace";
                                    //        private int _rsvcode;

        private static Boolean _Is_namespace;
        public Boolean Is_namespace
        {
            get
            {
                return (_Is_namespace);
            }
            set
            {
                _Is_namespace = value;
            }
        }
        #endregion

        #region コンストラクタ
        #endregion

        #region モジュール
        #endregion
    }
}
