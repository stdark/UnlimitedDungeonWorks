//Purely functional



#define _CRT_SECURE_NO_WARNINGS

#define DEFAULT_PORT "47016"
#define DEFAULT_BUFLEN 3512

//fc
#define _WINSOCK_DEPRECATED_NO_WARNINGS
#define ip "127.0.0.1"

#define bufsize 3512

//ec 


#include < winsock2.h > 
#include < ws2tcpip.h >
#include < iostream >
#include <string>
#include <fstream>
#include <stdio.h>

#pragma comment(lib, "Ws2_32.lib")





using namespace std;


int main()
{
	fstream fout;
	fout.open(".\\out.txt", std::fstream::in | std::fstream::app);
	int WALLET = 0;
	string res;
	int NUM = 0;

	for (string s; getline(fout, s); res = s) { NUM += 1; };
	if (!res.empty()) { WALLET = stoi(res, nullptr, 10); }
	else { WALLET = 0; }
	fout.close();

	int iResult;

	WSAData d;
	iResult = WSAStartup(MAKEWORD(2, 2), &d);
	if (iResult != 0)
	{
		std::cout << "Error at WSAStartup: " << iResult;
		return 1;
	}


	struct addrinfo *result = NULL, *ptr = NULL, hints;
	ZeroMemory(&hints, sizeof(hints));
	hints.ai_family = AF_INET;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;
	hints.ai_flags = AI_PASSIVE;


	iResult = getaddrinfo(NULL, DEFAULT_PORT, &hints, &result);
	if (iResult != 0)
	{
		std::cout << "Error getaddrinfo: " << iResult;
		WSACleanup();
		return 1;
	}


	SOCKET listenSocket = INVALID_SOCKET;
	listenSocket = socket(result->ai_family, result->ai_socktype, result->ai_protocol);
	if (listenSocket == INVALID_SOCKET)
	{

		std::cout << "Error at socket(): " << WSAGetLastError();
		freeaddrinfo(result);
		WSACleanup();
		return 1;
	}


	iResult = bind(listenSocket, result->ai_addr, result->ai_addrlen);


	if (iResult == SOCKET_ERROR)
	{



		std::cout << "Bind failed with error: " << WSAGetLastError();
		freeaddrinfo(result);
		closesocket(listenSocket);
		WSACleanup();
		return 1;
	}








	freeaddrinfo(result);




	if (listen(listenSocket, SOMAXCONN) == SOCKET_ERROR)
	{
		std::cout << "Listen failed with error: " << WSAGetLastError();
		closesocket(listenSocket);
		WSACleanup();
		return 1;
	}

	SOCKET ClientSocket;

	ClientSocket = INVALID_SOCKET;

	ClientSocket = accept(listenSocket, NULL, NULL);


	if (ClientSocket == INVALID_SOCKET)
	{
		std::cout << "Accept failed with error: " << WSAGetLastError();
		closesocket(listenSocket);
		WSACleanup();
		return 1;
	}
	else
	{
		fout.open(".\\out.txt",  std::fstream::out | std::fstream::app);
		
		


	}





	while (true) {
		char recvbuf[DEFAULT_BUFLEN];
		int iSendResult;
		int recvbuflen = DEFAULT_BUFLEN;

		int tmp = 0;
		char d[] = "Hello";

		// Принимаем данные от клиента
		iResult = recv(ClientSocket, recvbuf, recvbuflen, 0);
		if (iResult > 0)
		{

			
			std::cout << WALLET << "___Received " << iResult << " bytes:______";
			for (int i = 0; i < iResult; i++) 
			{
				if (recvbuf[i]==d[i]) { tmp += 1; }
				std::cout << recvbuf[i]; 
			}
			std::cout << "_____" << endl;


		}
		else if (iResult == 0)
		{
			std::cout << "Connection closed..." << std::endl;
		}
		else
		{
			std::cout << "Error recv " << WSAGetLastError();
			closesocket(ClientSocket);
			WSACleanup();
			return 1;
		}

		std::cout << tmp << endl;
		//sending

		if (tmp == 5) {

			WALLET += tmp;
			NUM += 1;
			fout << "№" << NUM << "__+=" << tmp << "__value_is:" << WALLET << endl;
			fout << WALLET << endl;
			
			string s = to_string(WALLET);
			char fdata[] = "";

			for (int i = 0; i < s.size(); i++)
			{
				fdata[i] = s.at(i);
			}

			//fflush(stdin);
			//fgets(fdata, 1256, stdin);

			//iSendResult = send(ClientSocket, fdata, static_cast<int>(strlen(fdata)), 0);
			iSendResult = send(ClientSocket, fdata, s.size(), 0);
			if (iSendResult == SOCKET_ERROR)
			{
				std::cout << "Send failed with error: " << WSAGetLastError();
				closesocket(ClientSocket);
				WSACleanup();
				return 1;
			}
			else { std::cout << "Send: " << static_cast<int>(strlen(fdata)) << "  "<< s << endl; }

		}
	}



	return 0;
}