using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApplication.Extensions
{
    public static class GuidExtension
    {
        /// <summary>
        /// Guid boş mu kontrol eder Boş ise hata fırlatır
        /// </summary>
        /// <param name="guid">Kontrol edilecek Guid</param>
        /// <returns>Geçerli Guid</returns>
        public static Guid ValidateNotEmpty(this Guid guid)
        {
            if (guid == Guid.Empty)
                throw new ArgumentException("bu değer boş olamaz veya geçersiz GUID değeri içeriyor");
            return guid;
        }
    }
}
