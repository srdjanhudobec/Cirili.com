import { Component } from '@angular/core';
import { Post } from 'src/models/Post.model';
import { PostService } from 'src/services/post.service';

@Component({
  selector: 'app-design',
  templateUrl: './design.component.html',
  styleUrls: ['./design.component.css']
})
export class DesignComponent {

  posts: Post [] = [];

  constructor(private postService:PostService){}

  ngOnInit(){
    this.postService.getPostByCategory("%D0%B4%D0%B8%D0%B7%D0%B0%D1%98%D0%BD").subscribe({
      next:(data:Post[])=> {
        data.forEach(element => {
          this.posts.push(element);
        });
      }
    })}
}
