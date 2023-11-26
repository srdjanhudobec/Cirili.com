export class Post{
    title: string;
    content: string;
    category: string
    

    constructor(title: string,content: string,category: string){
        this.title = title;
        this.content = content;
        this.category = category;
    }
}