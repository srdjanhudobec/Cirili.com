import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PostEdit } from 'src/models/PostEdit.model';
import { AuthService } from 'src/services/auth.service';
import { PostService } from 'src/services/post.service';

@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.css']
})
export class EditPostComponent {

  constructor(private postService:PostService,private router:Router,private authService:AuthService){}

  naslov:string = "";
  sadrzaj:string = "";

  odjava(){
    this.authService.logOut();
  }

  obrisi(){

    this.postService.deletePost(this.naslov).subscribe({
      next: () => {
      }
    })

    this.router.navigateByUrl('admin-panel');
  }

  izmeni(){
    this.postService.updatePost(this.naslov,new PostEdit(this.naslov,this.sadrzaj)).subscribe({
      next: () => {
      }
    })

    this.router.navigateByUrl('admin-panel');

  }
}
