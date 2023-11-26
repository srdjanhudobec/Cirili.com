import { Component } from '@angular/core';
import { Post } from 'src/models/Post.model';
import { PostService } from 'src/services/post.service';

@Component({
  selector: 'app-resources',
  templateUrl: './resources.component.html',
  styleUrls: ['./resources.component.css']
})
export class ResourcesComponent {
  posts: Post [] = [];

  constructor(private postService:PostService){}

  ngOnInit(){
    this.postService.getPostByCategory("%D1%80%D0%B5%D1%81%D1%83%D1%80%D1%81%D0%B8").subscribe({
      next:(data:Post[])=> {
        data.forEach(element => {
          this.posts.push(element);
        });
      }
    })}
}
