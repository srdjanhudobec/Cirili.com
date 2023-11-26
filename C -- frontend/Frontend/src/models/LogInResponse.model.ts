export class LogInResponse{
    token: string;
    expiration: string;
    username: string
    

    constructor(token: string,expiration: string,username: string){
        this.token = token;
        this.expiration = expiration;
        this.username = username;
    }
}