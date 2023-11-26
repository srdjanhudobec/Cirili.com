import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { Post } from 'src/models/Post.model';
import { PostEdit } from 'src/models/PostEdit.model';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  rootUrl:string = 'http://localhost:5248/api/Post/';

  constructor(private http: HttpClient,public router:Router) { }

  getAllRecipes() {
    let recipesUrl = this.rootUrl + 'get-posts';
    return this.http.get<Post[]>(recipesUrl);
  }

  getPostByCategory(category:string) {
    let recipesUrl = this.rootUrl + 'get-post-by-category?category=' + category;/*%D0%B4%D0%B8%D0%B7%D0%B0%D1%98%D0%BD*/
    return this.http.get<Post[]>(recipesUrl);
  }

  createPost(post: Post) : Observable<Post> {
    var url = this.rootUrl + 'create-post';
    var body = post;

    return this.http.post<Post>(url, body).pipe(
      map(response => {
        console.log(response);
        return new Post(response.title,response.content,response.category);
      })
    )
  }

  deletePost(title:string) : Observable<PostEdit> {
    var url = this.rootUrl + 'delete-post?title=' + title;

    return this.http.delete<Post>(url).pipe(
      map(response => {
        console.log(response);
        return new Post(response.title,response.content,response.category);
      })
    )
  }

  updatePost(title:string,postEdit:PostEdit) : Observable<PostEdit> {
    var url = this.rootUrl + 'update-post?title=' + title;

    return this.http.put<PostEdit>(url, postEdit).pipe(
      map(response => {
        // 4. Assuming there's a property in the response that you want to use for PostEdit
        console.log(response);
        return new PostEdit(response.title,response.content); // replace "someProperty" with the actual property you want to use
      })
    );
  }
}
