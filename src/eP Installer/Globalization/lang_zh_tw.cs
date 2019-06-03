using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eP_Installer.Globalization
{
    /*
     * Author:ePGameStudio
     * Original Language
     * 正體中文/繁體中文(臺灣)
     */
    public class Texts_Zh_tw
    {
        public static string exitinst_f = "你確定要離開本安裝程式嗎?\r\n此程式將不會被安裝於你的電腦中!\r\n\r\n按一下[是]以離開，[否]以繼續完成安裝程式。";

        public static string rebootneed = "{0}已安裝在你的電腦中，但是需要重新啟動你的電腦以完成此安裝程式，確保{0}能成功運行於你的電腦上。\r\n\r\n按一下[是]以重新開機，按一下「否」以在等一下再進行手動重新開機。";

        public static string error_nonexpag = "錯誤:安裝程式找不到下一個頁面。\r\n這可能是軟體開發者未指定下一個頁面所導致的。\r\n由於本安裝程式已無法成功運行此安裝，故將會結束此安裝程式。請聯絡軟體開發者，以取得進一步的支援。";

        public static string error_notfounfil = "錯誤:找不到文件{0}，請確認本文件與該安裝程式同目錄，或是手動指定{0}的位置!";

        public static string caution_permission = "錯誤:權限不足，請以管理員身分(UAC)執行。";

        public static string error_disk_space = "錯誤:安裝程式無法將檔案放置安裝目錄中，因為目標硬碟已經沒有空間來存放它。請把硬碟清出一些空間後，再嘗試安裝。";

        public static string finish_install = "「{0}」已成功安裝於你的電腦中。\r\n\r\n按一下「結束」以結束此安裝程式。";

        public static string finish_install_title = "{0}已經安裝完成";

        public static string wel_install_title = "歡迎使用「{0}」安裝程式";

        public static string wel_install_message = "此安裝程式將會引導你完成「測試用安裝程式」的安裝\r\n\r\n在安裝程序開始前，請先關閉其他程式。這將允許本程序更新指定的系統檔案，而不需要重新啟動你的電腦。\r\n\r\n按下「下一步」繼續。";

        //command-file
        public static string file_del = "正在刪除檔案:{0}";

        public static string file_tempdel = "正在刪除暫存檔案";

        public static string file_copy = "正在複製檔案到{0}";

        public static string error_file_permission = "錯誤:請提升權限後再試。";

        //Permission
        public static string usage_permission_File = "檔案存取";

        public static string usage_permission_Network = "網路連線";

        public static string usage_permission_Registry = "註冊表修改";

        public static string usage_permission_Dll = "元件註冊";

        public static string usage_permission_reboot = "重新啟動";

        public static string usage_permission_commericial = "廣告軟體";

        public static string usage_permission_unknown = "未知權限";

        public static string caution_commericial = "警告:本安裝可能會安裝額外不必要的廣告軟體，請注意。";

        public static string caution_virus = "警告:本安裝可能會使電腦資料遭竊取，請注意。";
    }
}
