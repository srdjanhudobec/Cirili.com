import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from 'src/models/Post.model';
import { AuthService } from 'src/services/auth.service';
import { PostService } from 'src/services/post.service';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent {

  constructor(private authService:AuthService,private postService:PostService,private router:Router){

  }

  naslov:string="";
  kategorija:string="razvoj";
  sadrzaj:string=""

  odjava(){
    this.authService.logOut();
  }

  submitForm() {
    var recipe = new Post(this.naslov,this.sadrzaj,this.kategorija);

    this.postService.createPost(recipe).subscribe({
      next: () => {
      }
    })

    this.router.navigateByUrl('admin-panel');
    

  }

}
