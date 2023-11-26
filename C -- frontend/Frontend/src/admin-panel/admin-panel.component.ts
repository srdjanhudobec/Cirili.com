import { Component } from '@angular/core';
import { Post } from 'src/models/Post.model';
import { AuthService } from 'src/services/auth.service';
import { PostService } from 'src/services/post.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent {

    podaciResursi: Post[] = [];
    podaciDizajn: Post[] = [];
    podaciRazvoj: Post[] = [];

    constructor(private postService:PostService,private authService:AuthService){

    }

    odjava(){
      this.authService.logOut();
    }

    ngOnInit(){
    
      this.postService.getPostByCategory("%D1%80%D0%B5%D1%81%D1%83%D1%80%D1%81%D0%B8").subscribe({
        next:(data:Post[])=> {
          data.forEach(element => {
            this.podaciResursi.push(element);
          });
        }
      })
      
      this.postService.getPostByCategory("%D1%80%D0%B0%D0%B7%D0%B2%D0%BE%D1%98").subscribe({
        next:(data:Post[])=> {
          data.forEach(element => {
            this.podaciRazvoj.push(element);
          });
        }
      })
      this.postService.getPostByCategory("%D0%B4%D0%B8%D0%B7%D0%B0%D1%98%D0%BD").subscribe({
        next:(data:Post[])=> {
          data.forEach(element => {
            this.podaciDizajn.push(element);
          });
        }
      })}
      

      
}
