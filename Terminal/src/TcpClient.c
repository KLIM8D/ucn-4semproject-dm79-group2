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

int main (int argc, char *argv[]) 
{
    int sd, rc, i;
    struct sockaddr_in localAddr, servAddr;
    struct hostent *h;
    
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
                strcat(message, ", \"TimeStamp\":\"");
                char *tmp = calloc(0, sizeof(char));
                time_t mytime = time(NULL);
                strftime(tmp, 25, "%d-%m-%Y %H:%M:%S", localtime(&mytime));
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
    
    return 0;
}

