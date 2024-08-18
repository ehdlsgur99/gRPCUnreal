package main

import (
	"context"
	"log"
	"time"

	pb "goServer/pb/hello"

	"google.golang.org/grpc"
	"google.golang.org/grpc/credentials/insecure"
)

func main() {
	//  insecure.NewCredentials() 전송 보안 비활성화 (테스트용)
	conn, err := grpc.NewClient("localhost:50051", grpc.WithTransportCredentials(insecure.NewCredentials()))
	if err != nil {
		log.Fatalf("did not connect: %v", err)
	}
	defer conn.Close()
	// 클라이언트 생성
	c := pb.NewHelloServiceClient(conn)

	ctx, cancel := context.WithTimeout(context.Background(), time.Second)
	defer cancel()

	name := "dxislike"
	// 서버의 sayHello 호출
	r, err := c.SayHello(ctx, &pb.HelloRequest{Greeting: name})
	if err != nil {
		log.Fatalf("could not greet: %v", err)
	}
	log.Printf("Greeting: %s", r.GetReply())
}
