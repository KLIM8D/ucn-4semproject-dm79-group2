#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <netdb.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <time.h>

#define SERVER_PORT 1500
#define MAX_MSG 100
#define ERROR 1
#define END_LINE 0x0

int read_line();

int main (int argc, char *argv[]) 
{
    int sd, rc, i, cliLen;
    struct sockaddr_in localAddr, servAddr;
    struct hostent *h;
    char line[MAX_MSG];
    
    if(argc < 3) {
        printf("usage: %s <server> <data1> <data2> ... <dataN>\n",argv[0]);
        exit(1);
    }

    h = gethostbyname(argv[1]);
    if(h == NULL) {
        printf("%s: unknown host '%s'\n",argv[0],argv[1]);
        exit(1);
    }

    servAddr.sin_family = h->h_addrtype;
    memcpy((char *) &servAddr.sin_addr.s_addr, h->h_addr_list[0], h->h_length);
    servAddr.sin_port = htons(SERVER_PORT);

    /* create socket */
    sd = socket(AF_INET, SOCK_STREAM, 0);
    if(sd < 0) {
        perror("cannot open socket ");
        exit(1);
    }

    /* bind any port number */
    localAddr.sin_family = AF_INET;
    localAddr.sin_addr.s_addr = htonl(INADDR_ANY);
    localAddr.sin_port = htons(0);
    
    rc = bind(sd, (struct sockaddr *) &localAddr, sizeof(localAddr));
    if(rc < 0) {
        printf("%s: cannot bind port TCP %u\n", argv[0], SERVER_PORT);
        perror("error ");
        exit(1);
    }
      			
    /* connect to server */
    rc = connect(sd, (struct sockaddr *) &servAddr, sizeof(servAddr));
    if(rc < 0) {
        perror("cannot connect ");
        exit(1);
    }

    char *message = calloc(128, sizeof(char));
    message[0] = '{';
    for(i = 2; i < 6; ++i) {
        switch(i) {
            case 2:
                strcat(message, "\"CardId\":");
                break;
            case 3:
                strcat(message, ", \"StationId\":");
                break;
            case 4:
                strcat(message, ", \"Type\":");
                break;
            case 5:
                strcat(message, ", \"TimeStamp\":\"/Date(");
                char *tmp = calloc(0, sizeof(char));
                /*time_t mytime = time(NULL);*/
                int x = (unsigned)time(NULL); 
                /*strftime(tmp, 25, "%d-%m-%Y %H:%M:%S)", localtime(&mytime));*/
                sprintf(tmp, "%d)/", x);
                strcat(message, tmp);
                break;
            }
        if(i != 5)
            strcat(message, argv[i]);
    }

    strcat(message, "\"}");
    rc = send(sd, message, strlen(message) + 1, 0); 
    if(rc < 0) {
        perror("cannot send data ");
        close(sd);
        exit(1);
    }
    printf("data%u sent (%s)\n", 1, message);

    while(1) {
        rc = recv(sd, line, sizeof(line),0);
        if ( rc <= 0 ) {
                printf("Either Connection Closed or Error\n");
                break;
        }

        printf("Status from server: -  %s\n",line);
        break;
    }
    
    close(sd);
    
    return 0;
}

/* read_lin returns the number of bytes returned in line_to_return       */
int read_line(int newSd, char *line_to_return) 
{
    static int rcv_ptr=0;
    static char rcv_msg[MAX_MSG];
    static int n;
    int offset;

    offset=0;

    while(1) {
        if(rcv_ptr==0) {
            /* read data from socket */
            memset(rcv_msg,0x0,MAX_MSG); /* init buffer */
            n = recv(newSd, rcv_msg, MAX_MSG, 0); /* wait for data */
            if (n < 0) {
                perror(" cannot receive data ");
                return ERROR;
            } 
            else if (n == 0) {
                printf(" connection closed by client\n");
                close(newSd);
                return ERROR;
            }
        }
    
      /* if new data read on socket */
      /* OR */
      /* if another line is still in buffer */

      /* copy line into 'line_to_return' */
      while(*(rcv_msg+rcv_ptr) != END_LINE && rcv_ptr < n) {
          memcpy(line_to_return+offset,rcv_msg+rcv_ptr,1);
          offset++;
          rcv_ptr++;
      }
      
      /* end of line + end of buffer => return line */
      if(rcv_ptr == n-1) { 
          /* set last byte to END_LINE */
          *(line_to_return+offset)=END_LINE;
          rcv_ptr = 0;
          return ++offset;
      } 
      
      /* end of line but still some data in buffer => return line */
      if(rcv_ptr < n-1) {
          /* set last byte to END_LINE */
          *(line_to_return+offset)=END_LINE;
          rcv_ptr++;
          return ++offset;
      }
      
      /* end of buffer but line is not ended => */
      /*  wait for more data to arrive on socket */
      if(rcv_ptr == n) {
        rcv_ptr = 0;
      } 
    }
}
