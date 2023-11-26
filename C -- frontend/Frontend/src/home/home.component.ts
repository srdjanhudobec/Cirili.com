import { Component } from '@angular/core';
import { Post } from 'src/models/Post.model';
import { PostService } from 'src/services/post.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
 
  posts: Post [] = [];
  counter: number = 0;

  constructor(private postService:PostService){}

  ngOnInit(){
    this.postService.getAllRecipes().subscribe({
      next:(data:Post[])=> {
        data.forEach(element => {
          if(this.counter < 3){
            this.posts.push(element);
            this.counter++;
          }
        });
      }
    })
   
  }
}
