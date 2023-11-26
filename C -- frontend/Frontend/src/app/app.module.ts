import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { LoginComponent } from '../login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { DesignComponent } from 'src/design/design.component';
import { DevelopmentComponent } from 'src/development/development.component';
import { ResourcesComponent } from 'src/resources/resources.component';
import { HeaderComponent } from '../header/header.component';
import { FooterComponent } from '../footer/footer.component';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { AuthInterceptorService } from 'src/services/auth-interceptor.service';
import { CommonModule, NgIf } from '@angular/common';
import { HomeComponent } from 'src/home/home.component';
import { AuthGuardService } from 'src/services/auth-guard.service';
import { AdminPanelComponent } from 'src/admin-panel/admin-panel.component';
import { AdminGuardService } from 'src/services/admin-guard.service';
import { FormsModule } from '@angular/forms';
import { CreatePostComponent } from 'src/create-post/create-post.component';
import { EditPostComponent } from 'src/edit-post/edit-post.component';
import { ConvertorComponent } from 'src/convertor/convertor.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full'},
  { path: 'login', component: LoginComponent,  pathMatch: 'full', canActivate:[AuthGuardService] },
  { path: 'design', component: DesignComponent,  pathMatch: 'full', canActivate:[AuthGuardService] },
  { path: 'development', component: DevelopmentComponent,  pathMatch: 'full', canActivate:[AuthGuardService] },
  { path: 'resources', component: ResourcesComponent,  pathMatch: 'full', canActivate:[AuthGuardService] },
  { path: 'home', component: HomeComponent,  pathMatch: 'full', canActivate:[AuthGuardService] },
  { path: 'admin-panel', component: AdminPanelComponent,  pathMatch: 'full', canActivate:[AdminGuardService]},
  { path: 'create-post', component: CreatePostComponent,  pathMatch: 'full', canActivate:[AdminGuardService]},
  { path: 'edit-post', component: EditPostComponent,  pathMatch: 'full', canActivate:[AdminGuardService]},
  { path: 'convert', component: ConvertorComponent,  pathMatch: 'full'}
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DesignComponent,
    ResourcesComponent,
    DevelopmentComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    AdminPanelComponent,
    CreatePostComponent,
    EditPostComponent,
    ConvertorComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    NgIf,
    FormsModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptorService,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule {

  
}
