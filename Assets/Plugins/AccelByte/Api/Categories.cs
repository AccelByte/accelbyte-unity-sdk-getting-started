﻿// Copyright (c) 2018 - 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using AccelByte.Core;
using AccelByte.Models;
using UnityEngine.Assertions;

namespace AccelByte.Api
{
    /// <summary>
    /// Provide an API to access Category service.
    /// </summary>
    public class Categories
    {
        private readonly CategoriesApi api;
        private readonly User user;
        private readonly AsyncTaskDispatcher taskDispatcher;
        private readonly CoroutineRunner coroutineRunner;

        internal Categories(CategoriesApi api, User user, AsyncTaskDispatcher taskDispatcher,
            CoroutineRunner coroutineRunner)
        {
            Assert.IsNotNull(api, "Can't construct Catalog manager; CatalogService parameter is null!");
            Assert.IsNotNull(user, "Can't construct Catalog manager; UserAccount parameter isnull!");
            Assert.IsNotNull(taskDispatcher, "taskReactor must not be null");
            Assert.IsNotNull(coroutineRunner, "coroutineRunner must not be null");

            this.api = api;
            this.user = user;
            this.taskDispatcher = taskDispatcher;
            this.coroutineRunner = coroutineRunner;
        }

        /// <summary>
        /// Get category info by its exact category path.
        /// </summary>
        /// <param name="categoryPath">Category path this category identified by</param>
        /// <param name="language">Display language</param>
        /// <param name="callback">Returns a Result that contains Category via callback when completed</param>
        public void GetCategory(string categoryPath, string language, ResultCallback<Category> callback)
        {
            Assert.IsNotNull(categoryPath, "Can't get category; CategoryPath parameter is null!");
            Assert.IsNotNull(language, "Can't get category; Language parameter is null!");

            if (!this.user.IsLoggedIn)
            {
                callback.TryError(ErrorCode.IsNotLoggedIn);
                return;
            }

            this.taskDispatcher.Start(
                Task.Retry(
                    cb => this.api.GetCategory(this.user.Namespace, this.user.AccessToken,
                        categoryPath, language, result => cb(result)),
                    result => this.coroutineRunner.Run(() => callback((Result<Category>) result)),
                    this.user));
        }

        /// <summary>
        /// Get all categories in root path
        /// </summary>
        /// <param name="language">Display language</param>
        /// <param name="callback">Returns a Result that contains Category array via callback when completed</param>
        public void GetRootCategories(string language, ResultCallback<Category[]> callback)
        {
            Assert.IsNotNull(language, "Can't get root categories; Language parameter is null!");

            if (!this.user.IsLoggedIn)
            {
                callback.TryError(ErrorCode.IsNotLoggedIn);
                return;
            }

            this.taskDispatcher.Start(
                Task.Retry(
                    cb => this.api.GetRootCategories(this.user.Namespace, this.user.AccessToken,
                        language, result => cb(result)),
                    result => this.coroutineRunner.Run(() => callback((Result<Category[]>) result)),
                    this.user));
        }

        /// <summary>
        /// Get child categories under category path
        /// </summary>
        /// <param name="categoryPath">Parent category path</param>
        /// <param name="language">Display language</param>
        /// <param name="callback">Returns a Result that contains Category array via callback when completed</param>
        public void GetChildCategories(string categoryPath, string language, ResultCallback<Category[]> callback)
        {
            Assert.IsNotNull(categoryPath, "Can't get child categories; CategoryPath parameter is null!");
            Assert.IsNotNull(language, "Can't get child categories; Language parameter is null!");

            if (!this.user.IsLoggedIn)
            {
                callback.TryError(ErrorCode.IsNotLoggedIn);
                return;
            }

            this.taskDispatcher.Start(
                Task.Retry(
                    cb => this.api.GetChildCategories(this.user.Namespace, this.user.AccessToken,
                        categoryPath, language, result => cb(result)),
                    result => this.coroutineRunner.Run(() => callback((Result<Category[]>) result)),
                    this.user));
        }

        /// <summary>
        /// Get all descendants of the category identified by category path. Descendant categories will also include
        /// grand children categories in flat Category array
        /// </summary>
        /// <param name="categoryPath">Parent category path</param>
        /// <param name="language">Display language</param>
        /// <param name="callback">Returns a Result that contains Category array via callback when completed</param>
        public void GetDescendantCategories(string categoryPath, string language,
            ResultCallback<Category[]> callback)
        {
            Assert.IsNotNull(categoryPath, "Can't get descendant categories; Language parameter is null!");
            Assert.IsNotNull(language, "Can't get descendant categories; Language parameter is null!");

            if (!this.user.IsLoggedIn)
            {
                callback.TryError(ErrorCode.IsNotLoggedIn);
                return;
            }

            this.taskDispatcher.Start(
                Task.Retry(
                    cb => this.api.GetDescendantCategories(this.user.Namespace, this.user.AccessToken,
                        categoryPath, language, result => cb(result)),
                    result => this.coroutineRunner.Run(() => callback((Result<Category[]>) result)),
                    this.user));
        }

    }
}
