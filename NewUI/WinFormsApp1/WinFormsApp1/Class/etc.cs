using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSLaunch.Class
{
    internal class etc
    {
        public static void DeleteDirectory(string directoryPath)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
                    Console.WriteLine("โฟลเดอร์ถูกลบเรียบร้อยแล้ว");
                }
                else
                {
                    Console.WriteLine("ไม่พบโฟลเดอร์ที่ต้องการลบ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("เกิดข้อผิดพลาดในการลบโฟลเดอร์: " + ex.Message);
            }
        }
    }
}
