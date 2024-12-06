﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _CommentListByArticleIdComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentListByArticleIdComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _commentService.TGetCommentsByArticleId(2);
            return View(values);
        }
    }
}
