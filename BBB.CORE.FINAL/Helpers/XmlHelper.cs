﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.CORE.FINAL.Helpers
{
    public class XmlHelper
    {
        // XML'den Nesneye Dönüştürme (Deserialize)
        public static T FromXml<T>(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new ArgumentNullException(nameof(xml), "XML string cannot be null or empty.");
            }

            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using (var reader = new StringReader(xml))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Deserialization error: {ex.InnerException?.Message ?? ex.Message}");
                throw;
            }
        }

        // XML Hata Yanıtı Oluşturma (Generic)
        public static string XmlErrorResponse<T>(string message, string details) where T : new()
        {
            var errorResponse = new T();

            var messageProperty = typeof(T).GetProperty("message", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            var detailsProperty = typeof(T).GetProperty("details", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (messageProperty != null)
            {
                messageProperty.SetValue(errorResponse, message);
            }

            if (detailsProperty != null)
            {
                detailsProperty.SetValue(errorResponse, details);
            }

            return ToXml(errorResponse);
        }

        // Nesneyi XML'e Dönüştürme (Serialize)
        public static string ToXml<T>(T value)
        {
            if (value == null)
            {
                return $"<ErrorResponse><Message>Serialization error</Message><Details>Value cannot be null.</Details></ErrorResponse>";
            }

            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using (var stringWriter = new StringWriter())
                {
                    serializer.Serialize(stringWriter, value);
                    var xmlResult = stringWriter.ToString();

                    // &amp; karakterlerini & ile değiştir
                    xmlResult = xmlResult.Replace("&amp;", "&");

                    Console.WriteLine($"Serialized XML: {xmlResult}"); // Loglama
                    return xmlResult;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Serialization error: {ex.InnerException?.Message ?? ex.Message}");
                return $"<ErrorResponse><Message>Serialization error</Message><Details>{ex.InnerException?.Message ?? ex.Message}</Details></ErrorResponse>";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error during serialization: {ex.Message}");
                return $"<ErrorResponse><Message>Unexpected error</Message><Details>{ex.Message}</Details></ErrorResponse>";
            }
        }
    }
}
