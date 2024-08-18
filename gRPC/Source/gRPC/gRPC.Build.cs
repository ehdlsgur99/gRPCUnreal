// Copyright Epic Games, Inc. All Rights Reserved.

using System.IO;
using UnrealBuildTool;

public class gRPC : ModuleRules
{
	public gRPC(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore", "EnhancedInput" });

		// gRPC 경로 설정
		string grpcPath = Path.Combine(ModuleDirectory, "ThirdParty", "grpc");

		// gRPC 라이브러리, 헤더 파일 경로
		PublicIncludePaths.Add(Path.Combine(grpcPath, "include"));
		PublicAdditionalLibraries.Add(Path.Combine(grpcPath, "lib","grpc.lib"));

        // 플랫폼 설정
        if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            string openSSLPath = Path.Combine(ModuleDirectory, "ThirdParty", "OpenSSL", "Win64");
            PublicIncludePaths.Add(Path.Combine(openSSLPath, "include"));
            PublicAdditionalLibraries.Add(Path.Combine(openSSLPath, "lib", "libssl.lib"));
            PublicAdditionalLibraries.Add(Path.Combine(openSSLPath, "lib", "libcrypto.lib"));
        }

        // 
        PublicDefinitions.Add("GRPC_USE_PROTO_LITE=0");
    }
}
