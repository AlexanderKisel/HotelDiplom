﻿using Hotel.Shared;

namespace Hotel.Models.Exceptions
{
    /// <summary>
    /// Информация об ошибках валидации работы АПИ
    /// </summary>
    public class ApiValidationExceptionDetail
    {
        /// <summary>
        /// Ошибки валидации
        /// </summary>
        public IEnumerable<InvalidateItemModel> Errors { get; set; } = Array.Empty<InvalidateItemModel>();
    }
}
