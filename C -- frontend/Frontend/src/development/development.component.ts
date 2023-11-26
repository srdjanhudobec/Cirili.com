import { Component } from '@angular/core';
import { Post } from 'src/models/Post.model';
import { PostService } from 'src/services/post.service';

@Component({
  selector: 'app-development',
  templateUrl: './development.component.html',
  styleUrls: ['./development.component.css']
})
export class DevelopmentComponent {
  posts: Post [] = [];

  constructor(private postService:PostService){}

  ngOnInit(){
    this.postService.getPostByCategory("%D1%80%D0%B0%D0%B7%D0%B2%D0%BE%D1%98").subscribe({
      next:(data:Post[])=> {
        data.forEach(element => {
          this.posts.push(element);
        });
      }
    })}
}
