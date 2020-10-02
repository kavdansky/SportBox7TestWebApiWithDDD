﻿using SportBox7.Domain.Exeptions;
using SportBox7.Domain.Models.Articles;
using SportBox7.Domain.Models.Articles.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportBox7.Domain.Factories.Articles
{
    internal class ArticleFactory : IArticleFactory
    {
        private string title = default!;
        private string body = default!;
        private string h1Tag = default!;
        private string imageUrl = default!;
        private string seoUrl = default!;
        private string metaDescription = default!;
        private string metaKeywords = default!;
        private Category category = default!;
        private ArticleType articleType = default!;
        private DateTime targetDate = default!;

        private bool isTitleSet = false;
        private bool isBodyset = false;
        private bool isH1TagSet = false;
        private bool isImageUrlSet = false;
        private bool isSeoUrlSet = false;
        private bool isMetaDescriptionSet = false;
        private bool isMetaKeywordsSet = false;
        private bool isCategorySet = false;
        private bool isArticleTypeSet = false;
        private bool isTargetDateSet = false;



        public IArticleFactory WithArticleType(ArticleType articleType)
        {
            this.articleType = articleType;
            this.isArticleTypeSet = true;
            return this;
        }

        public IArticleFactory WithBody(string body)
        {
            this.body = body;
            this.isBodyset = true;
            return this;
        }

        public IArticleFactory WithCategory(string name, string nameEn)
        {
            this.category =  new Category(name, nameEn);
            this.isCategorySet = true;
            return this;
        }

        public IArticleFactory WithH1Tag(string h1Tag)
        {
            this.h1Tag = h1Tag;
            this.isH1TagSet = true;
            return this;
        }

        public IArticleFactory WithImageUrl(string imageUrl)
        {
            this.imageUrl = imageUrl;
            this.isImageUrlSet = true;
            return this;
        }

        public IArticleFactory WithMetaDescription(string metaDescription)
        {
            this.metaDescription = metaDescription;
            this.isMetaDescriptionSet = true;
            return this;
        }

        public IArticleFactory WithMetaKeywords(string metaKeywords)
        {
            this.metaKeywords = metaKeywords;
            this.isMetaKeywordsSet = true;
            return this;
        }

        public IArticleFactory WithSeoUrl(string seoUrl)
        {
            this.seoUrl = seoUrl;
            this.isSeoUrlSet = true;
            return this;
        }

        public IArticleFactory WithTargetDate(DateTime targetDate)
        {
            this.isTargetDateSet = true;
            this.targetDate = targetDate;
            return this;
        }

        public IArticleFactory WithTitle(string title)
        {
            this.isTitleSet = true;
            this.title = title;
            return this;
        }

        public Article Build()
        {
            if (isTitleSet! || isBodyset! || isH1TagSet! || isImageUrlSet! && isSeoUrlSet! || isMetaDescriptionSet! || isMetaKeywordsSet! || isCategorySet! || isArticleTypeSet! || isTargetDateSet!)
            {
                throw new InvalidArticleException("Title, Body, H1Tag, ImageUrl, SeoUrl, MetaDescription, MetaKeywords, Category, Article and Target Date must have value!");
            }

            return new Article(this.title, this.body, this.h1Tag, this.imageUrl, this.seoUrl, this.metaDescription, this.metaKeywords, this.category, this.articleType, this.targetDate);
        }
    }
}
